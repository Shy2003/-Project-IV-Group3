using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerChatBox : Form
    {
        private ServerHandling server;

        public ServerChatBox()
        {
            InitializeComponent();

            //initially hide chat UI components to ensure they are only visible when the chat is active
            lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;

            //ensure the Connect to Server button is visible and Disconnect Server button is hidden at startup
            //this indicates that the user needs to connect before being able to chat
            guna2Button1.Visible = true;
            btnDisconnectServer.Visible = false;
            pictureBoxReceived.Visible = false;             //hide the picture box until an image is received.

            //setup the event handler for clearing the chat history
            //this allows the user to clear all messages from the chat interface
            btnClearChat.Click += (sender, e) => lstChat.Items.Clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e) // Start Server Button
        {
            // Initialize and start the server on a specific port (e.g., 13000)
            server = new ServerHandling(13000);

            // Subscribe to the MessageReceived event
            server.MessageReceived += (message) =>
            {
                // Update the lstChat ListBox with the received message
                // This needs to be done on the UI thread
                Invoke(new Action(() =>
                {
                    lstChat.Items.Add(message);
                }));
            };

            // Start the server
            server.Start();

            // Hide the Start Server button and show the Stop Server button
            guna2Button1.Visible = false;
            btnDisconnectServer.Visible = true;

            // Optionally, display a message to indicate that the server has started
            MessageBox.Show("Server started");
        }




        private void btnToggleChat_Click(object sender, EventArgs e) // Open ChatBox Button
        {
            ServerUI.ToggleChatVisibility(btnToggleChat, lstChat, txtMessage, btnSendMessage, btnSendImage, btnClearChat, lblInstructions);

        }

        private void lblInstructions_Click(object sender, EventArgs e) // Instruction Panel
        {

        }

        private void pictureBoxReceived_Click(object sender, EventArgs e) // Picture Box
        {

        }

        private void lstChat_SelectedIndexChanged(object sender, EventArgs e) // ChatBox
        {

        }

        private void btnDisconnectServer_Click(object sender, EventArgs e) // Stop server button
        {
            // Stop the server if it's running
            if (server != null)
            {
                server.Stop();
                server = null; // Set the server instance to null after stopping

                // Show the Start Server button and hide the Stop Server button
                guna2Button1.Visible = true;
                btnDisconnectServer.Visible = false;

                // Optionally, display a message to indicate that the server has stopped
                MessageBox.Show("Server stopped");
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
        }

        private void btnSendMessage_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSendMessage_Click_2(object sender, EventArgs e)
        {

            // Check if the server is running and there is a message to send
            if (server != null && !string.IsNullOrEmpty(txtMessage.Text))
            {
                try
                {
                    // Send the message to the client
                    server.SendMessage(txtMessage.Text);

                    // Update the lstChat ListBox with the sent message
                    lstChat.Items.Add("Server: " + txtMessage.Text);

                    // Clear the txtMessage TextBox after sending the message
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    // Show an error message if something goes wrong
                    MessageBox.Show("Error sending message: " + ex.Message);
                }
            }
        }
    }
}
