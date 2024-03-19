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

        // Test

        private void StartServer()
        {
            //ServerHandling server = new ServerHandling(13000);
            //server.Start();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e) // Start Server button
        {
            //Task.Run(() => StartServer());
        }

        private void guna2Button3_Click(object sender, EventArgs e)     //this opens the chatbox for the server
        {
            ServerChatBox serverChatBox = new ServerChatBox();

            serverChatBox.ShowDialog();
        }
    }
}
