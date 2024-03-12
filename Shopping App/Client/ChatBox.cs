using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

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
            //initially hide chat UI components to ensure they are only visible when the chat is active
            lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;

            //setup event handler for toggling the chat box's visibility
            //this allows the user to open or close the chat box
            btnToggleChat.Click += (sender, e) =>
                ChatBoxToggler.ToggleChat(btnToggleChat, lstChat, txtMessage, btnSendMessage, btnSendImage, btnClearChat, lblInstructions);

            //ensure the Connect to Server button is visible and Disconnect Server button is hidden at startup
            //this indicates that the user needs to connect before being able to chat
            guna2Button1.Visible = true;
            btnDisconnectServer.Visible = false;
            pictureBoxReceived.Visible = false;             //hide the picture box until an image is received.

            //setup the event handler for clearing the chat history
            //this allows the user to clear all messages from the chat interface
            btnClearChat.Click += (sender, e) => lstChat.Items.Clear();

            //setup the event handler for disconnecting from the server
            //this allows the user to manually disconnect from the chat server
            btnDisconnectServer.Click += (sender, e) =>
            {
                ServerConnectionHandler.DisconnectFromServer(client, guna2Button1, btnDisconnectServer);
            };

            //setup the event handler for sending text messages
            //this sends the user's message to the server and displays it in the chat interface
            btnSendMessage.Click += (sender, e) =>
            {
                ServerCommunicationHandler.SendMessage(client, txtMessage.Text.Trim(), txtMessage, DisplayMessage);
            };

            //setup the event handler for sending images
            //this allows the user to send an image file to the server and notifies the chat interface
            btnSendImage.Click += (sender, e) =>
            {
                ServerCommunicationHandler.SendImage(client, DisplayMessage);
            };

            //setup the event handler for connecting to the server
            //this initiates a connection to the chat server and sets up the interface for chatting
            guna2Button1.Click += (sender, e) =>
            {
                client = ServerConnectionHandler.ConnectToServer(
                    "127.0.0.1", 13000,
                    guna2Button1, btnDisconnectServer,
                    DisplayMessage,             //delegate for handling text messages received from the server
                    DisplayReceivedImage            //delegate for handling images received from the server
                );

                // If the connection was successful, start listening for incoming data.
                if (client != null && client.IsConnected)
                {
                    //subscribe to events for receiving text messages and images
                    client.TextMessageReceived += OnTextMessageReceived;
                    client.ImageReceived += OnImageReceived;
                }
            };
        }

        //this method gets called when a text message is received
        private void OnTextMessageReceived(string message)
        {
            UIUpdater.DisplayMessage(lstChat, "Server: " + message);
        }

        //this method gets called when an image is received
        private void OnImageReceived(byte[] imageData)
        {
            UIUpdater.DisplayReceivedImage(pictureBoxReceived, imageData);
        }

        //event handler for toggling the chat box open/close
        private void btnToggleChat_Click(object sender, EventArgs e)
        {
            ////check current visibility state of the chat box to determine action
            //bool isChatOpen = btnSendMessage.Visible;

            //if (!isChatOpen)
            //{
            //    //if chatbox is not open, open it and hide instructions
            //    lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = true;
            //    lblInstructions.Visible = false;        //hide the instructional text
            //    btnToggleChat.Text = "Close Chatbox";
            //}
            //else
            //{
            //    //if chatbox is open, prompt the user to clear the chat history upon closing
            //    var result = MessageBox.Show("Do you want to clear chat history?", "Clear History", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        //clear chat history if the user chooses yes
            //        lstChat.Items.Clear();
            //    }

            //    //close the chat box and show the instructions again
            //    lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;
            //    lblInstructions.Visible = true;
            //    btnToggleChat.Text = "Open Chatbox";
            //}
        }

        //clears the chat history
        private void btnClearChat_Click(object sender, EventArgs e)
        {
            //lstChat.Items.Clear();
        }

        //attempts to connect or disconnect from the server depending on current state
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ////show message on successful connection and toggle visibility of connect/disconnect buttons
            //client = new PC01Connection("127.0.0.1", 13000);
            //if (client.Connect())
            //{
            //    MessageBox.Show("Connected to server.");
            //    guna2Button1.Visible = false;
            //    btnDisconnectServer.Visible = true;
            //}
            //else
            //{
            //    MessageBox.Show("Failed to connect to the server.");
            //}
        }

        //handles disconnection from the server
        private void btnDisconnectServer_Click(object sender, EventArgs e)
        {
            //if (client != null)
            //{
            //    client.Disconnect();
            //    MessageBox.Show("Disconnected from server.");
            //    //toggle visibility to show Connect to Server button again
            //    guna2Button1.Visible = true;
            //    btnDisconnectServer.Visible = false;
            //}
        }

        //sends a message to the server and displays the servers response
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //string message = txtMessage.Text.Trim();
            //if (!string.IsNullOrEmpty(message))
            //{
            //    if (client == null || !client.IsConnected)
            //    {
            //        client = new PC01Connection("127.0.0.1", 13000);
            //        if (!client.Connect())
            //        {
            //            MessageBox.Show("Failed to connect to the server.");
            //            return;
            //        }
            //    }

            //    client.SendMessage(message);
            //    DisplayMessage("Me: " + message);           //**use DisplayMessage to add to UI
            //    txtMessage.Clear();
            //}
        }


        //opens a dialog for the user to select an image to send
        private void btnSendImage_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog
            //{
            //    Filter = "Image Files|*.jpg;*.jpeg;*.png;"
            //};
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string imagePath = openFileDialog.FileName;
            //    if (client == null || !client.IsConnected)
            //    {
            //        client = new PC01Connection("127.0.0.1", 13000);
            //        if (!client.Connect())
            //        {
            //            MessageBox.Show("Failed to connect to the server.");
            //            return;
            //        }
            //    }

            //    client.SendImage(imagePath);
            //    DisplayMessage("Me: [Image sent]");         //**use DisplayMessage
            //}
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
            //placeholder for any actions that should be triggered when the instructions label is clicked. Currently, it does nothing :)
        }

        private void AttemptConnection()
        {
            ////creates a new PC01Connection with the server IP and port, attempts to connect
            //client = new PC01Connection("127.0.0.1", 13000);
            //if (client.Connect())
            //{
            //    MessageBox.Show("Connected to server.");
            //    //subscribes to text and image received events from the server
            //    client.TextMessageReceived += OnTextMessageReceived;
            //    client.ImageReceived += OnImageReceived;

            //    //updates the UI to reflect the connection status
            //    guna2Button1.Visible = false;
            //    btnDisconnectServer.Visible = true;
            //}
            //else
            //{
            //    MessageBox.Show("Failed to connect to the server.");
            //}
        }

        private void DisplayMessage(string message)
        {
            //// Add message to UI, ensure this runs on the UI thread
            //if (InvokeRequired)
            //{
            //    Invoke(new Action<string>(DisplayMessage), message);
            //}
            //else
            //{
            //    lstChat.Items.Add(message);
            //}
        }

        private void DisplayReceivedImage(byte[] imageData)
        {
            //// Ensures image processing runs on the UI thread and sets the received image to the PictureBox
            //Invoke(new Action(() =>
            //{
            //    using (var ms = new MemoryStream(imageData))
            //    {
            //        var image = Image.FromStream(ms);
            //        pictureBoxReceived.Image = image;
            //        // Makes the PictureBox visible when displaying an image
            //        pictureBoxReceived.Visible = true;
            //    }
            //}));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //this is where the image recieved from server would be shown, it is currently hidden until an image is recieved
        }
    }
}
