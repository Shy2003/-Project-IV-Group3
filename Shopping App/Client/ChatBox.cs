using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_PC01
{
    public partial class ChatBox : Form
    {
        //client connection object for managing server communication
        private PC01Connection client;

        //constructor initializes the form and sets initial visibility states for UI components
        public ChatBox()
        {
            InitializeComponent();
            //hide chat UI components until the chatbox is explicitly opened
            lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;
            //ensure the button Connect to Server is visible and Disconnect Server is hidden initially
            guna2Button1.Visible = true;
            btnDisconnectServer.Visible = false;
        }

        //event handler for toggling the chat box open/close
        private void btnToggleChat_Click(object sender, EventArgs e)
        {
            //check current visibility state of the chat box to determine action
            bool isChatOpen = btnSendMessage.Visible;

            if (!isChatOpen)
            {
                //if chatbox is not open, open it and hide instructions
                lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = true;
                lblInstructions.Visible = false;        //hide the instructional text
                btnToggleChat.Text = "Close Chatbox";
            }
            else
            {
                //if chatbox is open, prompt the user to clear the chat history upon closing
                var result = MessageBox.Show("Do you want to clear chat history?", "Clear History", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //clear chat history if the user chooses yes
                    lstChat.Items.Clear();
                }

                //close the chat box and show the instructions again
                lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;
                lblInstructions.Visible = true;
                btnToggleChat.Text = "Open Chatbox";
            }
        }

        //clears the chat history
        private void btnClearChat_Click(object sender, EventArgs e)
        {
            lstChat.Items.Clear();
        }

        //attempts to connect or disconnect from the server depending on current state
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //show message on successful connection and toggle visibility of connect/disconnect buttons
            client = new PC01Connection("127.0.0.1", 13000);
            if (client.Connect())
            {
                MessageBox.Show("Connected to server.");
                guna2Button1.Visible = false;
                btnDisconnectServer.Visible = true;
            }
            else
            {
                MessageBox.Show("Failed to connect to the server.");
            }
        }

        //handles disconnection from the server
        private void btnDisconnectServer_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Disconnect();
                MessageBox.Show("Disconnected from server.");
                //toggle visibility to show Connect to Server button again
                guna2Button1.Visible = true;
                btnDisconnectServer.Visible = false;
            }
        }

        //sends a message to the server and displays the servers response
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                if (client == null || !client.IsConnected)      //check if not connected or client is null
                {
                    client = new PC01Connection("127.0.0.1", 13000);
                    if (!client.Connect())
                    {
                        MessageBox.Show("Failed to connect to the server.");
                        return;         //exit the method if connection fails
                    }
                }

                //assuming connection is now established, send the message
                string response = client.SendMessage(message);
                lstChat.Items.Add("Me: " + message);
                lstChat.Items.Add("Server: " + response);
                txtMessage.Clear();

                //keep the session alive for ongoing communication
            }
        }

        //opens a dialog for the user to select an image to send
        private void btnSendImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                //check if already connected or if the client is null
                if (client == null || !client.IsConnected)
                {
                    client = new PC01Connection("127.0.0.1", 13000);
                    if (!client.Connect())
                    {
                        MessageBox.Show("Failed to connect to the server.");
                        return;         //exit if connection fails ;(
                    }
                }

                //if connected, proceed to send the image :)
                bool success = client.SendImage(imagePath);
                if (success)
                {
                    lstChat.Items.Add("Me: [Image sent]");
                }
                else
                {
                    lstChat.Items.Add("Failed to send image.");
                }

                //Note: I am assuming we don't need to receive a confirmation message from the server here
                //keep the session alive for further communication
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            //potentially to be used
        }

        private void lstChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this might be used if selecting chat items should trigger actions, I doubt it though
        }

        private void lblInstructions_Click(object sender, EventArgs e)
        {

        }
    }
}
