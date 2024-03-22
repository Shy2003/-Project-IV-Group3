using Client_PC01;

namespace Client
{
    public partial class Client_PC01 : Form
    {
        public Client_PC01()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e) // Connect to Server button
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
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            // Open the PC selection form
            PCSelectionForm pcSelectionForm = new PCSelectionForm();
            pcSelectionForm.PCSelected += PCSelectionForm_PCSelected; // Subscribe to the PCSelected event
            pcSelectionForm.ShowDialog();
        }

        private void PCSelectionForm_PCSelected(object sender, string pcNumber)
        {
            // Open the OrderPageForm with the selected PC number
            OrderPageForm orderPageForm = new OrderPageForm(pcNumber);
            orderPageForm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

