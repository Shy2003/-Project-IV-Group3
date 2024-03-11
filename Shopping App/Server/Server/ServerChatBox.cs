using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class ServerChatBox : Form
    {
        private ServerHandling server; // Instance of ServerHandling class


        public ServerChatBox()
        {
            InitializeComponent();
            server = new ServerHandling(8080);

            // Subscribe to events
            server.OnMessageReceived += UpdateReceivedTextMessage;
            server.OnImageReceived += UpdateReceivedImage;

            server.Start(); // Start the server to listen for incoming connections
        }

        private void button1_Click(object sender, EventArgs e)      //close chatbox
        {
            // Close the chatbox form
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)       //sender label
        {

        }

        private void label2_Click(object sender, EventArgs e)       //PC Name label
        {
            string senderName = "PC Name";
            UpdateSender(senderName);
        }

        private void label3_Click(object sender, EventArgs e)       //received message label
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)       //textbox to display message
        {

        }

        private void label4_Click(object sender, EventArgs e)           //recieved picture label
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)      //picturebox for picture
        {

        }

        private void label5_Click(object sender, EventArgs e)       //enter reply label
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)       //textbox to type reply
        {

        }

        private void button2_Click(object sender, EventArgs e)      //send button
        {

        }






        private void UpdateSender(string senderName)
        {
            // Update the sender label with the name of the PC sending the message
            if (label2.InvokeRequired)
            {
                label2.Invoke((MethodInvoker)delegate
                {
                    label2.Text = senderName;
                });
            }
            else
            {
                label2.Text = senderName;
            }
        }

        // Updates the UI with received text message
        private void UpdateReceivedTextMessage(string message)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((MethodInvoker)delegate { textBox1.AppendText(message + Environment.NewLine); });
            }
            else
            {
                textBox1.AppendText(message + Environment.NewLine);
            }
        }

        // Updates the UI with received image
        private void UpdateReceivedImage(byte[] imageData)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke((MethodInvoker)delegate
                {
                    DisplayImage(imageData);
                });
            }
            else
            {
                DisplayImage(imageData);
            }
        }

        // Helper method to display image from byte array
        private void DisplayImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            // Example sender name update
            UpdateSender("Client Name");
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
