using Client_PC01;

namespace Client
{
    public partial class Client_PC01 : Form
    {
        private PC01Connection client;
        private PictureBox pictureBoxReceived;
        public Client_PC01()
        {
            InitializeComponent();
            InitializePictureBoxReceived();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e) // Connect to Server button
        {
            //client = new PC01Connection("127.0.0.1", 13000);
            //if (client.Connect())
            //{
            //    client.TextMessageReceived += Client_TextMessageReceived;
            //    client.ImageReceived += Client_ImageReceived;
            //}
            //else
            //{
            //    MessageBox.Show("Failed to connect to the server.");
            //}
        }

        private void Client_TextMessageReceived(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                // Update your UI here, e.g., display the message in a text box
                MessageBox.Show($"Received message: {message}");
            });
        }

        private void Client_ImageReceived(byte[] imageData)
        {
            Invoke((MethodInvoker)delegate
            {
                // Handle the image data, e.g., display it in pictureBoxReceived
                using (var ms = new MemoryStream(imageData))
                {
                    pictureBoxReceived.Image = Image.FromStream(ms);
                }
            });
        }

        private void InitializePictureBoxReceived()
        {
            pictureBoxReceived = new PictureBox();
            pictureBoxReceived.Location = new Point(10, 10); // Adjust location as needed
            pictureBoxReceived.Size = new Size(200, 200); // Adjust size as needed
            pictureBoxReceived.SizeMode = PictureBoxSizeMode.StretchImage; // Optional: Adjust for better image fit
            this.Controls.Add(pictureBoxReceived);
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //create a new instance of the ChatBox form.
            ChatBox chatBox = new ChatBox();

            //ShowDialog() if we want the ChatBox form to be modal (like the user must close it before accessing other forms)
            //or Show() for the form to be non-modal like how it is currently implemented for clients only
            chatBox.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}