using System;
using System.Windows.Forms;

namespace Client_PC01
{
    public partial class ChatBox : Form
    {
        private PC01Connection client;

        public ChatBox()
        {
            InitializeComponent();

            lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;
            guna2Button1.Visible = true;
            btnDisconnectServer.Visible = false;
            pictureBoxReceived.Visible = true;

            btnToggleChat.Click += (sender, e) => UIUpdater.ToggleChatVisibility(btnToggleChat, lstChat, txtMessage, btnSendMessage, btnSendImage, btnClearChat, lblInstructions);
            btnClearChat.Click += (sender, e) => lstChat.Items.Clear();
            guna2Button1.Click += (sender, e) => AttemptConnection();
            btnDisconnectServer.Click += (sender, e) => DisconnectFromServer();
            btnSendMessage.Click += (sender, e) => SendMessageToServer();
            btnSendImage.Click += (sender, e) => SendImageToServer();
        }


        private void AttemptConnection()
        {
            client = new PC01Connection("127.0.0.1", 13000);
            if (client.Connect())
            {
                MessageBox.Show("Connected to server.");
                guna2Button1.Visible = false;
                btnDisconnectServer.Visible = true;
                btnSendMessage.Enabled = true;
                client.TextMessageReceived += OnTextMessageReceived;
                client.ImageReceived += OnImageReceived;
            }
            else
            {
                MessageBox.Show("Failed to connect to the server.");
            }
        }

        private void DisconnectFromServer()
        {
            if (client != null)
            {
                client.Disconnect();
                guna2Button1.Visible = true;
                btnDisconnectServer.Visible = false;
                btnSendMessage.Enabled = false;
            }
        }

        private void SendMessageToServer()
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                client.SendTextMessage(txtMessage.Text);
                lstChat.Items.Add("You: " + txtMessage.Text);
                txtMessage.Clear();
            }
        }


        private void SendImageToServer()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Read the image file into a byte array
                byte[] imageBytes = File.ReadAllBytes(filePath);

                // Send the byte array to the server
                client.SendImage(imageBytes);

                // Update the PictureBox with the sent image
                pictureBoxReceived.Image = Image.FromFile(filePath);
            }
        }



        private void OnTextMessageReceived(string message)
        {
            lstChat.Invoke(new Action(() => lstChat.Items.Add("Server: " + message)));


        }

        private void OnImageReceived(byte[] imageBytes)
        {
            Invoke(new Action(() =>
            {
                using (var ms = new MemoryStream(imageBytes))
                {
                    pictureBoxReceived.Image = Image.FromStream(ms);
                }
            }));
        }

        private void btnClearChat_Click(object sender, EventArgs e)
        {
            lstChat.Items.Clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void lstChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Not implemented
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            // Not implemented
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SendMessageToServer();
        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {
       
        }

        private void btnToggleChat_Click(object sender, EventArgs e)
        {
        }

        private void btnDisconnectServer_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
        }

        private void pictureBoxReceived_Click(object sender, EventArgs e)
        {
            // Not implemented
        }

        private void lblInstructions_Click(object sender, EventArgs e)
        {
            // Your code for lblInstructions_Click
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Your code for pictureBox1_Click
        }

    }
}
