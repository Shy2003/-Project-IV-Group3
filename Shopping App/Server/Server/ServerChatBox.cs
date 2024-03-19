using System;
using System.Drawing;
using System.Windows.Forms;

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
            pictureBoxReceived.Visible = true;

            btnToggleChat.Click += (sender, e) => ServerUI.ToggleChatVisibility(btnToggleChat, lstChat, txtMessage, btnSendMessage, btnSendImage, btnClearChat, lblInstructions);
            btnClearChat.Click += (sender, e) => lstChat.Items.Clear();
            guna2Button1.Click += (sender, e) => StartServer();
            btnDisconnectServer.Click += (sender, e) => StopServer();
            btnSendMessage.Click += (sender, e) => SendMessageToClients();
            btnSendImage.Click += (sender, e) => SendImageToClient();

        }

        private void StartServer()
        {
            server = new ServerHandling(13000);
            server.TextMessageReceived += OnMessageReceived;
            server.ImageReceived += OnImageReceived; // Subscribe to the ImageReceived event
            MessageBox.Show("Server started");
            guna2Button1.Visible = false;
            btnDisconnectServer.Visible = true;
        }

        private void OnMessageReceived(string message)
        {
            lstChat.Invoke(new Action(() => lstChat.Items.Add("Client: " + message)));
        }

        private void OnImageReceived(byte[] imageBytes)
        {
            Invoke(new Action(() =>
            {
                using (var ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    pictureBoxReceived.Image = image; // Display the image in the PictureBox
                    pictureBoxReceived.Visible = true; // Make sure the PictureBox is visible
                }
            }));
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
                    server.SendTextMessage(txtMessage.Text); // 
                    lstChat.Items.Add("Server: " + txtMessage.Text);
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message);
                }
            }
        }

        private void SendImageToClient()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                server.SendImage(filePath);
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

        private void btnSendImage_Click(object sender, EventArgs e)
        {

        }
    }
}
