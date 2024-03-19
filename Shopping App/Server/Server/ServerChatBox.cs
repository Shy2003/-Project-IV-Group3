namespace Server
{
    public partial class ServerChatBox : Form
    {
        private ServerHandling server;

        public ServerChatBox()
        {
            InitializeComponent();

            lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;
            guna2Button1.Visible = true;
            btnDisconnectServer.Visible = false;
            pictureBoxReceived.Visible = false;

            btnToggleChat.Click += (sender, e) => ServerUI.ToggleChatVisibility(btnToggleChat, lstChat, txtMessage, btnSendMessage, btnSendImage, btnClearChat, lblInstructions);
            btnClearChat.Click += (sender, e) => lstChat.Items.Clear();
            guna2Button1.Click += (sender, e) => StartServer();
            btnDisconnectServer.Click += (sender, e) => StopServer();
            btnSendMessage.Click += (sender, e) => SendMessageToClients();
        }

        private void StartServer()
        {
            server = new ServerHandling(13000);
            server.MessageReceived += (message) =>
            {
                Invoke(new Action(() =>
                {
                    lstChat.Items.Add("Client:" + message);
                }));
            };
            MessageBox.Show("Server started");
            guna2Button1.Visible = false;
            btnDisconnectServer.Visible = true;
        }

        private void StopServer()
        {
            if (server != null)
            {
                server.Stop();
                server = null;
                MessageBox.Show("Server stopped");
                guna2Button1.Visible = true;
                btnDisconnectServer.Visible = false;
            }
        }

        private void SendMessageToClients()
        {
            if (server != null && !string.IsNullOrEmpty(txtMessage.Text))
            {
                try
                {
                    server.SendMessage(txtMessage.Text);
                    lstChat.Items.Add("Server: " + txtMessage.Text);
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message);
                }
            }
        }

        private void btnDisconnectServer_Click(object sender, EventArgs e)
        {
        }

        private void btnSendMessage_Click_2(object sender, EventArgs e)
        {
            
        }

        private void btnToggleChat_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void lblInstructions_Click(object sender, EventArgs e)
        {
        }

        private void lstChat_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBoxReceived_Click(object sender, EventArgs e)
        {
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
