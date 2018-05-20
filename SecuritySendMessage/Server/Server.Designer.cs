namespace Server
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lbKey = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSecretkey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbltime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtkeyclient = new System.Windows.Forms.TextBox();
            this.TimerSession = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Enabled = false;
            this.txtKey.Location = new System.Drawing.Point(479, 32);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(314, 20);
            this.txtKey.TabIndex = 26;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(11, 280);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(460, 55);
            this.txtMessage.TabIndex = 24;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.ForeColor = System.Drawing.Color.Black;
            this.lbKey.Location = new System.Drawing.Point(476, 15);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(60, 13);
            this.lbKey.TabIndex = 29;
            this.lbKey.Text = "Key server:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(476, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Private key:";
            // 
            // txbSecretkey
            // 
            this.txbSecretkey.Enabled = false;
            this.txbSecretkey.Location = new System.Drawing.Point(479, 108);
            this.txbSecretkey.Name = "txbSecretkey";
            this.txbSecretkey.Size = new System.Drawing.Size(314, 20);
            this.txbSecretkey.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Message :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbltime);
            this.groupBox3.Location = new System.Drawing.Point(479, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(82, 73);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thời Gian";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.Location = new System.Drawing.Point(15, 29);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(61, 20);
            this.lbltime.TabIndex = 0;
            this.lbltime.Text = "lbltime";
            this.lbltime.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(476, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Key client:";
            // 
            // txtkeyclient
            // 
            this.txtkeyclient.Enabled = false;
            this.txtkeyclient.Location = new System.Drawing.Point(479, 70);
            this.txtkeyclient.Name = "txtkeyclient";
            this.txtkeyclient.Size = new System.Drawing.Size(314, 20);
            this.txtkeyclient.TabIndex = 36;
            // 
            // TimerSession
            // 
            this.TimerSession.Tick += new System.EventHandler(this.TimerSession_Tick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(479, 280);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(61, 54);
            this.btnSend.TabIndex = 38;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 11);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(461, 251);
            this.listBox1.TabIndex = 40;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(808, 344);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtkeyclient);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbSecretkey);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtMessage);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.Load += new System.EventHandler(this.Server_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSecretkey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtkeyclient;
        private System.Windows.Forms.Timer TimerSession;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox listBox1;
    }
}

