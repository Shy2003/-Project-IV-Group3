using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Task.Run(() => StartServer());
        }

        private void StartServer()
        {
            ServerHandling server = new ServerHandling("127.0.0.1", 13000);
            server.Start();
        }
    }
}
