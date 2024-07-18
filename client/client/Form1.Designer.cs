namespace client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tbIP = new TextBox();
            label1 = new Label();
            tbPort = new TextBox();
            label2 = new Label();
            btConnect = new Button();
            btShare = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tbIP
            // 
            tbIP.Location = new Point(29, 80);
            tbIP.Multiline = true;
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(311, 50);
            tbIP.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 43);
            label1.Name = "label1";
            label1.Size = new Size(27, 25);
            label1.TabIndex = 1;
            label1.Text = "IP";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(29, 208);
            tbPort.Multiline = true;
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(311, 52);
            tbPort.TabIndex = 0;
            tbPort.Text = "80";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 160);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 1;
            label2.Text = "PORT";
            // 
            // btConnect
            // 
            btConnect.Location = new Point(55, 298);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(112, 34);
            btConnect.TabIndex = 2;
            btConnect.Text = "CONNECT";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += btConnect_Click;
            // 
            // btShare
            // 
            btShare.Location = new Point(203, 298);
            btShare.Name = "btShare";
            btShare.Size = new Size(112, 34);
            btShare.TabIndex = 2;
            btShare.Text = "SHARE";
            btShare.UseVisualStyleBackColor = true;
            btShare.Click += btShare_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 376);
            Controls.Add(btShare);
            Controls.Add(btConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPort);
            Controls.Add(tbIP);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbIP;
        private Label label1;
        private TextBox tbPort;
        private Label label2;
        private Button btConnect;
        private Button btShare;
        private System.Windows.Forms.Timer timer1;
    }
}
