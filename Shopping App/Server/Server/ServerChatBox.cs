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
        private UIUpdater uiUpdater;    //Instance of UIUpdater Class

        public ServerChatBox()
        {
            InitializeComponent();
            // Initialize the server instance
            server = new ServerHandling(13000);


            // Create an instance of UIUpdater with the required UI controls
            uiUpdater = new UIUpdater(textBox1, label2, pictureBox1);

            // Subscribe to events
            server.OnMessageReceived += uiUpdater.UpdateReceivedTextMessage;
            server.OnImageReceived += uiUpdater.UpdateReceivedImage;

            //start() function is already called in the ServerHomePage.cs when "Start Server" is clicked
            //server.Start(); // Start the server to listen for incoming connections
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
            uiUpdater.UpdateSender(senderName);
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
            //UpdateSender("Client Name");
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
