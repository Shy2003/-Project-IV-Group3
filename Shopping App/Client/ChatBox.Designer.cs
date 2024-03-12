namespace Client_PC01
{
    partial class ChatBox
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

        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendImage;
        private Guna.UI2.WinForms.Guna2Button btnToggleChat;
        private Guna.UI2.WinForms.Guna2Button btnClearChat;
        private System.Windows.Forms.Label lblInstructions;
        private Guna.UI2.WinForms.Guna2Button btnDisconnectServer;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatBox));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblInstructions = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            lstChat = new ListBox();
            txtMessage = new TextBox();
            btnSendMessage = new Guna.UI2.WinForms.Guna2Button();
            btnSendImage = new Guna.UI2.WinForms.Guna2Button();
            btnToggleChat = new Guna.UI2.WinForms.Guna2Button();
            btnClearChat = new Guna.UI2.WinForms.Guna2Button();
            btnDisconnectServer = new Guna.UI2.WinForms.Guna2Button();
            pictureBoxReceived = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxReceived).BeginInit();
            SuspendLayout();
            // 
            // lblInstructions
            // 
            lblInstructions.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            lblInstructions.Location = new Point(348, 32);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(1228, 781);
            lblInstructions.TabIndex = 0;
            lblInstructions.Text = resources.GetString("lblInstructions.Text");
            lblInstructions.Click += lblInstructions_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Maroon;
            guna2Button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(23, 84);
            guna2Button1.Margin = new Padding(2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(287, 66);
            guna2Button1.TabIndex = 0;
            guna2Button1.Text = "Connect to Server";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // lstChat
            // 
            lstChat.ItemHeight = 25;
            lstChat.Location = new Point(335, 2);
            lstChat.Margin = new Padding(2);
            lstChat.Name = "lstChat";
            lstChat.Size = new Size(1241, 754);
            lstChat.TabIndex = 1;
            lstChat.SelectedIndexChanged += lstChat_SelectedIndexChanged;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(335, 782);
            txtMessage.Margin = new Padding(2);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(1077, 31);
            txtMessage.TabIndex = 2;
            txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // btnSendMessage
            // 
            btnSendMessage.CustomizableEdges = customizableEdges3;
            btnSendMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSendMessage.ForeColor = Color.White;
            btnSendMessage.Location = new Point(1416, 760);
            btnSendMessage.Margin = new Padding(2);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSendMessage.Size = new Size(160, 36);
            btnSendMessage.TabIndex = 3;
            btnSendMessage.Text = "Send";
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // btnSendImage
            // 
            btnSendImage.CustomizableEdges = customizableEdges5;
            btnSendImage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSendImage.ForeColor = Color.White;
            btnSendImage.Location = new Point(1416, 800);
            btnSendImage.Margin = new Padding(2);
            btnSendImage.Name = "btnSendImage";
            btnSendImage.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSendImage.Size = new Size(160, 36);
            btnSendImage.TabIndex = 4;
            btnSendImage.Text = "Send an Image";
            btnSendImage.Click += btnSendImage_Click;
            // 
            // btnToggleChat
            // 
            btnToggleChat.CustomizableEdges = customizableEdges7;
            btnToggleChat.FillColor = Color.Olive;
            btnToggleChat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnToggleChat.ForeColor = Color.White;
            btnToggleChat.Location = new Point(23, 191);
            btnToggleChat.Name = "btnToggleChat";
            btnToggleChat.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnToggleChat.Size = new Size(287, 66);
            btnToggleChat.TabIndex = 5;
            btnToggleChat.Text = "Open Chatbox";
            btnToggleChat.Click += btnToggleChat_Click;
            // 
            // btnClearChat
            // 
            btnClearChat.CustomizableEdges = customizableEdges9;
            btnClearChat.FillColor = Color.Olive;
            btnClearChat.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            btnClearChat.ForeColor = Color.White;
            btnClearChat.Location = new Point(23, 191);
            btnClearChat.Name = "btnClearChat";
            btnClearChat.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnClearChat.Size = new Size(287, 66);
            btnClearChat.TabIndex = 6;
            btnClearChat.Text = "Clear Chat";
            btnClearChat.Visible = false;
            btnClearChat.Click += btnClearChat_Click;
            // 
            // btnDisconnectServer
            // 
            btnDisconnectServer.CustomizableEdges = customizableEdges11;
            btnDisconnectServer.FillColor = Color.Green;
            btnDisconnectServer.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            btnDisconnectServer.ForeColor = Color.White;
            btnDisconnectServer.Location = new Point(23, 84);
            btnDisconnectServer.Name = "btnDisconnectServer";
            btnDisconnectServer.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnDisconnectServer.Size = new Size(287, 66);
            btnDisconnectServer.TabIndex = 7;
            btnDisconnectServer.Text = "Disconnect Server";
            btnDisconnectServer.Visible = false;
            btnDisconnectServer.Click += btnDisconnectServer_Click;
            // 
            // pictureBoxReceived
            // 
            pictureBoxReceived.Location = new Point(361, 374);
            pictureBoxReceived.Name = "pictureBoxReceived";
            pictureBoxReceived.Size = new Size(508, 341);
            pictureBoxReceived.TabIndex = 8;
            pictureBoxReceived.TabStop = false;
            pictureBoxReceived.Click += pictureBox1_Click;
            // 
            // ChatBox
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1580, 847);
            Controls.Add(pictureBoxReceived);
            Controls.Add(lblInstructions);
            Controls.Add(guna2Button1);
            Controls.Add(lstChat);
            Controls.Add(txtMessage);
            Controls.Add(btnSendMessage);
            Controls.Add(btnSendImage);
            Controls.Add(btnToggleChat);
            Controls.Add(btnClearChat);
            Controls.Add(btnDisconnectServer);
            Margin = new Padding(2);
            Name = "ChatBox";
            Text = "ChatBox";
            ((System.ComponentModel.ISupportInitialize)pictureBoxReceived).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private PictureBox pictureBoxReceived;
    }
}