namespace Client
{
    partial class Client
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbKey = new System.Windows.Forms.Label();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            
            this.label2 = new System.Windows.Forms.Label();
            this.txtFinalKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtkeyserver = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbltime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimeSession = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(9, 266);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(450, 55);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Message :";
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.ForeColor = System.Drawing.Color.Black;
            this.lbKey.Location = new System.Drawing.Point(464, 23);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(56, 13);
            this.lbKey.TabIndex = 21;
            this.lbKey.Text = "Key client:";
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Enabled = false;
            this.txtPublicKey.Location = new System.Drawing.Point(467, 39);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(314, 20);
            this.txtPublicKey.TabIndex = 20;
           
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(464, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Private key:";
            // 
            // txtFinalKey
            // 
            this.txtFinalKey.Enabled = false;
            this.txtFinalKey.Location = new System.Drawing.Point(467, 119);
            this.txtFinalKey.Name = "txtFinalKey";
            this.txtFinalKey.Size = new System.Drawing.Size(314, 20);
            this.txtFinalKey.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(464, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Key server:";
            // 
            // txtkeyserver
            // 
            this.txtkeyserver.Enabled = false;
            this.txtkeyserver.Location = new System.Drawing.Point(467, 78);
            this.txtkeyserver.Name = "txtkeyserver";
            this.txtkeyserver.Size = new System.Drawing.Size(314, 20);
            this.txtkeyserver.TabIndex = 28;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbltime);
            this.groupBox3.Location = new System.Drawing.Point(467, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(82, 73);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thời gian";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.Location = new System.Drawing.Point(15, 30);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(61, 20);
            this.lbltime.TabIndex = 0;
            this.lbltime.Text = "lbltime";
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbltime.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimeSession
            // 
            this.TimeSession.Tick += new System.EventHandler(this.TimeSession_Tick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(463, 266);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(61, 54);
            this.btnSend.TabIndex = 37;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 11);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(449, 238);
            this.listBox1.TabIndex = 39;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(793, 332);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtkeyserver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFinalKey);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMessage);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.TextBox txtPublicKey;
        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFinalKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtkeyserver;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer TimeSession;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox listBox1;
    }
}

