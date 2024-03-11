using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerHomePage : Form
    {
        public ServerHomePage()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void guna2Button13_Click(object sender, EventArgs e) // Start Server button
        {
            // Start the server
            ServerHandling server = new ServerHandling(13000);
            server.Start();

            // Update the status label
            lblStatus.Text = "Status: Server is running";

            // Show a message box indicating that the server is running
            MessageBox.Show("Server is running", "Server Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ServerChatBox serverChatBox = new ServerChatBox();

            serverChatBox.ShowDialog();
        }
    }
}
