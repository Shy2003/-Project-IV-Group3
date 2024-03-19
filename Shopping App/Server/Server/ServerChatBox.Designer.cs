namespace Server
{
    partial class ServerChatBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerChatBox));
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
            pictureBoxReceived = new PictureBox();
            lblInstructions = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            lstChat = new ListBox();
            txtMessage = new TextBox();
            btnSendMessage = new Guna.UI2.WinForms.Guna2Button();
            btnSendImage = new Guna.UI2.WinForms.Guna2Button();
            btnToggleChat = new Guna.UI2.WinForms.Guna2Button();
            btnClearChat = new Guna.UI2.WinForms.Guna2Button();
            btnDisconnectServer = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxReceived).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxReceived
            // 
            pictureBoxReceived.Image = (Image)resources.GetObject("pictureBoxReceived.Image");
            pictureBoxReceived.Location = new Point(352, 378);
            pictureBoxReceived.Name = "pictureBoxReceived";
            pictureBoxReceived.Size = new Size(508, 341);
            pictureBoxReceived.TabIndex = 18;
            pictureBoxReceived.TabStop = false;
            pictureBoxReceived.Click += pictureBoxReceived_Click;
            // 
            // lblInstructions
            // 
            lblInstructions.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            lblInstructions.Location = new Point(340, 21);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(1228, 781);
            lblInstructions.TabIndex = 9;
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
            guna2Button1.Location = new Point(14, 88);
            guna2Button1.Margin = new Padding(2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(287, 66);
            guna2Button1.TabIndex = 10;
            guna2Button1.Text = "Start Server";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // lstChat
            // 
            lstChat.ItemHeight = 25;
            lstChat.Location = new Point(326, 6);
            lstChat.Margin = new Padding(2);
            lstChat.Name = "lstChat";
            lstChat.Size = new Size(1241, 754);
            lstChat.TabIndex = 11;
            lstChat.SelectedIndexChanged += lstChat_SelectedIndexChanged;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(326, 786);
            txtMessage.Margin = new Padding(2);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(1077, 31);
            txtMessage.TabIndex = 12;
            txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // btnSendMessage
            // 
            btnSendMessage.CustomizableEdges = customizableEdges3;
            btnSendMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSendMessage.ForeColor = Color.White;
            btnSendMessage.Location = new Point(1407, 764);
            btnSendMessage.Margin = new Padding(2);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSendMessage.Size = new Size(160, 36);
            btnSendMessage.TabIndex = 13;
            btnSendMessage.Text = "Send";
            btnSendMessage.Click += btnSendMessage_Click_2;
            // 
            // btnSendImage
            // 
            btnSendImage.CustomizableEdges = customizableEdges5;
            btnSendImage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSendImage.ForeColor = Color.White;
            btnSendImage.Location = new Point(1407, 804);
            btnSendImage.Margin = new Padding(2);
            btnSendImage.Name = "btnSendImage";
            btnSendImage.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSendImage.Size = new Size(160, 36);
            btnSendImage.TabIndex = 14;
            btnSendImage.Text = "Send an Image";
            btnSendImage.Click += btnSendImage_Click;
            // 
            // btnToggleChat
            // 
            btnToggleChat.CustomizableEdges = customizableEdges7;
            btnToggleChat.FillColor = Color.Olive;
            btnToggleChat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnToggleChat.ForeColor = Color.White;
            btnToggleChat.Location = new Point(14, 195);
            btnToggleChat.Name = "btnToggleChat";
            btnToggleChat.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnToggleChat.Size = new Size(287, 66);
            btnToggleChat.TabIndex = 15;
            btnToggleChat.Text = "Open Chatbox";
            btnToggleChat.Click += btnToggleChat_Click;
            // 
            // btnClearChat
            // 
            btnClearChat.CustomizableEdges = customizableEdges9;
            btnClearChat.FillColor = Color.Olive;
            btnClearChat.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            btnClearChat.ForeColor = Color.White;
            btnClearChat.Location = new Point(14, 195);
            btnClearChat.Name = "btnClearChat";
            btnClearChat.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnClearChat.Size = new Size(287, 66);
            btnClearChat.TabIndex = 16;
            btnClearChat.Text = "Clear Chat";
            btnClearChat.Visible = false;
            // 
            // btnDisconnectServer
            // 
            btnDisconnectServer.CustomizableEdges = customizableEdges11;
            btnDisconnectServer.FillColor = Color.Green;
            btnDisconnectServer.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            btnDisconnectServer.ForeColor = Color.White;
            btnDisconnectServer.Location = new Point(14, 88);
            btnDisconnectServer.Name = "btnDisconnectServer";
            btnDisconnectServer.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnDisconnectServer.Size = new Size(287, 66);
            btnDisconnectServer.TabIndex = 17;
            btnDisconnectServer.Text = "Stop Server";
            btnDisconnectServer.Visible = false;
            btnDisconnectServer.Click += btnDisconnectServer_Click;
            // 
            // ServerChatBox
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
            Name = "ServerChatBox";
            Text = "ServerChatBox";
            ((System.ComponentModel.ISupportInitialize)pictureBoxReceived).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblInstructions;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private ListBox lstChat;
        private TextBox txtMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendImage;
        private Guna.UI2.WinForms.Guna2Button btnToggleChat;
        private Guna.UI2.WinForms.Guna2Button btnClearChat;
        private Guna.UI2.WinForms.Guna2Button btnDisconnectServer;
        public PictureBox pictureBoxReceived;
    }
}