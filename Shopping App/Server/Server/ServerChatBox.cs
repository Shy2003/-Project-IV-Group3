using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerChatBox : Form
    {
        ServerHandling server;

        public ServerChatBox()
        {
            InitializeComponent();
            server = new ServerHandling(13000);
        }

        private void label2_Click(object sender, EventArgs e)       //"Recieved Messages" Label
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if there is any selected item in the list box
            if (RecievedMessages.SelectedItem != null)
            {
                // Get the selected item
                string selectedItem = RecievedMessages.SelectedItem.ToString();

                // Assuming you have a method to create or obtain a TcpClient object based on the selected item
                // Here, you would need to implement this method or provide a way to create the TcpClient object
                TcpClient client = server.CreateTcpClientFromSelectedItem(selectedItem);

                // Check if the client object is not null
                if (client != null)
                {
                    // Call the HandleClient method to start processing the client connection
                    server.HandleClient(client, RecievedMessages);
                }
                else
                {
                    // Handle the case where the TcpClient object could not be created
                    MessageBox.Show("Failed to create TcpClient object.");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)      //"Enter message to broadcast" label
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)       //textbox for message
        {

        }


        private void button1_Click(object sender, EventArgs e)           //send button
        {

            // Get the message from the text box
            string message = textBox1.Text;

            // Send the message to the server
            if (server != null)
            {
                server.SendMessage(message);

                // Clear the text box after sending the message
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Server is not running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)           //server running label
        {

        }
    }
}
