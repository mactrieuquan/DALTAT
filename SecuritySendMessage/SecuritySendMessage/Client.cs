using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        
        IPEndPoint IP;
        Socket client;
        
        Aes_EcbEncrypt aes = new Aes_EcbEncrypt();
        byte[] khoapublic;
        byte[] khoabimat;
        string keypublic;
        string keysecret;
        byte[] nhankey;
        byte[] nhankeydadoi;
        byte[] data;
        byte[] tinnhan;
        byte[] keypublicduocguilai = new byte[1024];

        SHA sha256 = new SHA();
        DiffieHellman Diff = new DiffieHellman();
        
        string dateTimeIV;
        byte[] dateTimeIv;
        
        MD5 md5 = new MD5();

       
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối tới server","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
            byte[] nhandodai = new byte[1024];
            client.Receive(nhandodai);           
            nhankey = new byte[BitConverter.ToInt32(nhandodai, 0)];           
            client.Receive(nhankey);         
            keypublic = Convert.ToBase64String(nhankey);
            txtkeyserver.Text = keypublic;
            TaoKey();
            Diff.LayKhoaBiMat(nhankey);
            khoabimat = Diff.aes.Key;
            keysecret = Convert.ToBase64String(khoabimat);
            txtFinalKey.Text = keysecret;
            byte[] laydodai = BitConverter.GetBytes(khoapublic.Length);
            client.Send(laydodai);
            byte[] Keypublic = khoapublic;
            client.Send(Keypublic);               
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        void TaoKey()
        {
            Diff = new DiffieHellman();
            khoapublic = Diff.PublicKey;
            keypublic = Convert.ToBase64String(khoapublic);
            txtPublicKey.Text = keypublic;          
        }

        void guilaipublickey()
        {
            byte[] batdauguikey = Encoding.UTF8.GetBytes("guikeyserver");
            client.Send(batdauguikey);
            byte[] Keypublic = khoapublic;           
            client.Send(Keypublic);
        }

        void guiPublickeyChoServer()
        {
            byte[] batdauguikey = Encoding.UTF8.GetBytes("guikeytoserver");
            client.Send(batdauguikey);
            byte[] Keypublic = khoapublic;
            client.Send(Keypublic);
        }
        
        void Send()
        {
            dateTimeIV = md5.maHoaMd5(DateTime.Now.ToString());
            string time = dateTimeIV.Substring(0, 16);
            dateTimeIv = Encoding.UTF8.GetBytes(time);
            string a = txtFinalKey.Text.Substring(0, 32);
            byte[] key = Encoding.ASCII.GetBytes(a);
            string s = aes.EncryptString(txtMessage.Text, key, dateTimeIv);

            byte[] mahoa = Diff.MaHoaDiffie(nhankey, s);
            byte[] dodai = BitConverter.GetBytes(mahoa.Length);
            byte[] initvector = Diff.IV;            
            if (client != null && txtMessage.Text != string.Empty)
            {
                client.Send(dodai);
                client.Send(mahoa);
                client.Send(initvector);
            }            
        }

        
        void AddMessage(string s)
        {
            listBox1.Items.Add("Server: "+ s);
            txtMessage.Clear();
        }

        void AddSelfMessage(string s)
        {
            listBox1.Items.Add("Client: " + s );
            txtMessage.Clear();
        }
        void MessageHeTHong(string s)
        {
            listBox1.Items.Add("System: " + s);
        }
        
        void Receive()
        {       
            try
            {
               while (true)
                {
                    data = new byte[1024];
                    client.Receive(data);     
                    
                    if (string.Equals(Encoding.UTF8.GetString(data), "guikey", StringComparison.InvariantCultureIgnoreCase))
                    {                                               
                        txtkeyserver.Clear();
                        txtFinalKey.Clear();
                        nhankeydadoi = new byte[140];
                        client.Receive(nhankeydadoi);                        
                        keypublic = Convert.ToBase64String(nhankeydadoi);
                        txtkeyserver.Text = keypublic;
                        TaoKey();
                        Diff.LayKhoaBiMat(nhankeydadoi);
                        khoabimat = Diff.aes.Key;
                        keysecret = Convert.ToBase64String(khoabimat);
                        txtFinalKey.Text = keysecret;
                        nhankey = nhankeydadoi;
                        guilaipublickey();
                    }
                    else if (string.Equals(Encoding.UTF8.GetString(data), "guikeytoclient", StringComparison.InvariantCultureIgnoreCase))
                    {
                        txtkeyserver.Clear();
                        txtFinalKey.Clear();
                        nhankeydadoi = new byte[140];
                        client.Receive(nhankeydadoi);
                        keypublic = Convert.ToBase64String(nhankeydadoi);
                        txtkeyserver.Text = keypublic;                        
                        Diff.LayKhoaBiMat(nhankeydadoi);
                        khoabimat = Diff.aes.Key;
                        keysecret = Convert.ToBase64String(khoabimat);
                        txtFinalKey.Text = keysecret;
                        nhankey = nhankeydadoi;                       
                    }
                    else
                    {
                        dateTimeIV = md5.maHoaMd5(DateTime.Now.ToString());
                        string time = dateTimeIV.Substring(0, 16);
                        dateTimeIv = Encoding.UTF8.GetBytes(time);

                        tinnhan = new byte[BitConverter.ToInt32(data, 0)];
                        client.Receive(tinnhan);
                        byte[] nhanvector = new byte[16];
                        client.Receive(nhanvector);
                        string message = Diff.GiaiMaDiffie(nhankey, tinnhan, nhanvector);
                        string a = txtFinalKey.Text.Substring(0, 32);
                        byte[] key = Encoding.ASCII.GetBytes(a);
                        string s = aes.DecryptString(message, key, dateTimeIv);
                        AddMessage(s);
                }
            }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Send();
            AddSelfMessage(txtMessage.Text);
            txtMessage.Clear();
            timer1.Start();
            sec = 15;
            timer1.Start();
        }

        Aes_EcbEncrypt AES = new Aes_EcbEncrypt();
        
        //thêm random
        
        private void Client_Load(object sender, EventArgs e)
        {
            TimeSession.Start();
        }
        
        int sec = 15;
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
                txtkeyserver.Clear();
                txtFinalKey.Clear();
                TaoKey();
                guiPublickeyChoServer();
                laptime();
            }
            sec--;  
        }

        private void TimeSession_Tick(object sender, EventArgs e)
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

        private void laptime()
        {
            sec = 15;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}
