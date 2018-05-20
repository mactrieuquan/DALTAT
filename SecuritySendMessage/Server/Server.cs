using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            Connect();

        }
        //md5
        MD5 md5 = new MD5();
        //AES-256     
        Aes_EcbEncrypt aes = new Aes_EcbEncrypt();
        //IP 
        IPEndPoint IP;
        Socket client;
        //Socket(lỗ kết nối )
        Socket server;
        byte[] khoapublic;
        byte[] khoabimat;      
        //Danh sách lưu trữ tất cả client kết nối
        List<Socket> clientList;
        int sec = 15;
        // public key, secret key
        string keypublic;
        string keysecret;
        string keyclient;
        DiffieHellman diff;
        byte[] nhankey;
        byte[] data;
        byte[] tinnhan;
        byte[] nhankeydadoi;
        //Datime Iv
        string dateTimeIV;
        byte[] dateTimeIv;

        
        void Connect()
        {
            clientList = new List<Socket>();
            //IP của server (127.0.0.1)
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //đợi ip
            server.Bind(IP);

            Thread listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        client = server.Accept();                       
                        clientList.Add(client);
                        // lấy độ dài khóa public của server
                        byte[] laydodai = BitConverter.GetBytes(khoapublic.Length);
                        // gửi độ dài khóa public cho client
                        client.Send(laydodai);                       
                        // lấy khóa public
                        byte[] Keypublic = khoapublic;
                        // gửi khóa public cho client
                        client.Send(Keypublic);                     
                        // Nhận độ dài của khóa public từ client
                        byte[] nhandodai = new byte[1024];
                        client.Receive(nhandodai);
                        // Nhận khóa public của client
                        nhankey = new byte[BitConverter.ToInt32(nhandodai, 0)];
                        client.Receive(nhankey);
                        // add vào textbox
                        keyclient = Convert.ToBase64String(nhankey);
                        txtkeyclient.Text = keyclient;
                        //Lấy khóa public từ client để tạo khóa chung
                        diff.LayKhoaBiMat(nhankey);
                        khoabimat = diff.aes.Key;
                        keysecret = Convert.ToBase64String(khoabimat);
                        txbSecretkey.Text = keysecret;
                        Thread receive = new Thread(Receive);                        
                        receive.IsBackground = true;
                        receive.Start(client);                       
                    }
                }
                catch
                {
                    MessageBox.Show("Có lỗi trao đổi Key");
                }
            });
            TaoKey();
            listen.IsBackground = true;
            listen.Start();
        }

        void TaoKey()
        {
            diff = new DiffieHellman();
            khoapublic = diff.PublicKey;
            keypublic = Convert.ToBase64String(khoapublic);
            txtKey.Text = keypublic;           
        }

        void guilaipublickey()
        {
            byte[] batdauguikey = Encoding.UTF8.GetBytes("guikey");
            client.Send(batdauguikey);                   
            byte[] Keypublic = khoapublic;
            client.Send(Keypublic);            
        }

        void guiLaiKeyChoClientVuaGui()
        {
            byte[] batdauguikey = Encoding.UTF8.GetBytes("guikeytoclient");
            client.Send(batdauguikey);
            byte[] Keypublic = khoapublic;
            client.Send(Keypublic);
        }   
        
        void Send(Socket client)
        {
            dateTimeIV = md5.maHoaMd5(DateTime.Now.ToString());
            string time = dateTimeIV.Substring(0, 16);
            dateTimeIv = Encoding.UTF8.GetBytes(time);
            string a = txbSecretkey.Text.Substring(0, 32);
            byte[] key = Encoding.ASCII.GetBytes(a);
            string s = aes.EncryptString(txtMessage.Text,key, dateTimeIv);

            byte[] mahoa = diff.MaHoaDiffie(nhankey, s);
            byte[] dodai = BitConverter.GetBytes(mahoa.Length);
            byte[] initvector = diff.IV;            
            if (client != null && txtMessage.Text != string.Empty)
            {               
                client.Send(dodai);
                client.Send(mahoa);
                client.Send(initvector);              
            }
           
        }
        
        void AddMessage(string s)
        {
            listBox1.Items.Add("Client: " + s);
            txtMessage.Clear();
        }

        void Messagefromself(string s)
        {
            listBox1.Items.Add("Server: " + s );
            txtMessage.Clear();
        }
        void MessageHeTHong(string s)
        {
            listBox1.Items.Add("System: " + s);
        }
        
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)//luôn luôn nhận
                {
                    data = new byte[1024];
                    client.Receive(data);
                    if (string.Equals(Encoding.UTF8.GetString(data), "guikeyserver", StringComparison.InvariantCultureIgnoreCase))
                    {                       
                        nhankeydadoi = new byte[140];
                        client.Receive(nhankeydadoi);
                        keypublic = Convert.ToBase64String(nhankeydadoi);
                        txtkeyclient.Text = keypublic;                        
                        diff.LayKhoaBiMat(nhankeydadoi);
                        khoabimat = diff.aes.Key;
                        keysecret = Convert.ToBase64String(khoabimat);
                        txbSecretkey.Text = keysecret;
                        nhankey = nhankeydadoi;                        
                    }
                    else if (string.Equals(Encoding.UTF8.GetString(data), "guikeytoserver", StringComparison.InvariantCultureIgnoreCase))
                    {                       
                        nhankeydadoi = new byte[140];
                        client.Receive(nhankeydadoi);                 
                        keypublic = Convert.ToBase64String(nhankeydadoi);
                        txtkeyclient.Text = keypublic;
                        TaoKey();
                        diff.LayKhoaBiMat(nhankeydadoi);
                        khoabimat = diff.aes.Key;
                        keysecret = Convert.ToBase64String(khoabimat);
                        txbSecretkey.Text = keysecret;
                        nhankey = nhankeydadoi;
                        guiLaiKeyChoClientVuaGui();
                    }
                    else
                    {
                        tinnhan = new byte[BitConverter.ToInt32(data, 0)];
                        client.Receive(tinnhan);
                        byte[] nhanvector = new byte[16];
                        client.Receive(nhanvector);
                        string message = diff.GiaiMaDiffie(nhankey, tinnhan, nhanvector);

                        dateTimeIV = md5.maHoaMd5(DateTime.Now.ToString());
                        string time = dateTimeIV.Substring(0, 16);
                        dateTimeIv = Encoding.UTF8.GetBytes(time);
                        string a = txbSecretkey.Text.Substring(0, 32);
                        byte[] key = Encoding.ASCII.GetBytes(a);
                        string s = aes.DecryptString(message, key, dateTimeIv);
                        
                        AddMessage(s);
                    }
                }
            }

            catch
            {
                clientList.Remove(client);
                client.Close();
            }

        }

        
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
        
        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Close();
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            Messagefromself(txtMessage.Text);
            txtMessage.Clear();
            sec = 15;
            timer1.Start();
            
        }
                
        private void timer1_Tick(object sender, EventArgs e)
        {            
            lbltime.Visible = true;
            lbltime.Text = sec.ToString();
            if (sec < 10)
            {
                lbltime.Text = "0" + sec.ToString();
            }
            if (sec <= 0)
            {
                timer1.Stop();
                txtkeyclient.Clear();
                txbSecretkey.Clear();
                TaoKey();
                guilaipublickey();
                laptime();
            }
            sec--;                        
        }

        private void laptime()
        {
            sec = 15;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();       
        }

        private void Server_Load(object sender, EventArgs e)
        {
            TimerSession.Start();
        }

        private void TimerSession_Tick(object sender, EventArgs e)
        {
            dateTimeIV = md5.maHoaMd5(DateTime.Now.ToString());
            string time = dateTimeIV.Substring(0, 16);
            dateTimeIv = Encoding.UTF8.GetBytes(time);
            
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtMessage.Text != "")
            {
                btnSend.PerformClick();
                txtMessage.Clear();
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text.Replace(Environment.NewLine, "");
        }

        
    }
}
