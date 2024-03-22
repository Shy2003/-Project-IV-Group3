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
        public ChatBox()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PC01Connection client = new PC01Connection("127.0.0.1", 13000);
            if (client.Connect())
            {
                string response = client.SendMessage("Hello, Server!");
                MessageBox.Show($"Response from server: {response}");
                client.Disconnect();
            }
            else
            {
                MessageBox.Show("Failed to connect to the server.");
            }

            // Perform chatting
        }

        private void ChatBox_Load(object sender, EventArgs e)
        {

        }
    }
}
