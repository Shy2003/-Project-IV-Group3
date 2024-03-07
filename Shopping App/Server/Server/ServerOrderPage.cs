using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerOrderPage : Form
    {
        public ServerOrderPage()
        {
            InitializeComponent();
        }

        private void ServerOrderPage_Load(object sender, EventArgs e)
        {
            // changing text test
            String exampleText = "PC 01";
            PcName.Text = exampleText;

            // BELOW WILL BE TURNED INTO PROPER METHOD LATER - TESTING PURPOSES ONLY
            // cloning order panel test
            int PanelOffset = OrderBox.Location.Y + OrderBox.Height + 15;
            Guna.UI2.WinForms.Guna2Panel mainBoxCopy = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = OrderBox.Size,
                FillColor = OrderBox.FillColor,
                Location = new Point(OrderBox.Location.X, PanelOffset),
                Parent = OrderItems,
                Name = "OrderBox2"
            };
            // cloning children of main panel
            Guna.UI2.WinForms.Guna2Panel titleBoxCopy = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = PcNameBox.Size,
                FillColor = PcNameBox.FillColor,
                Location = PcNameBox.Location,
                Parent = mainBoxCopy,
                Name = "PcNameBox2"
            };
            Guna.UI2.WinForms.Guna2Panel listBoxCopy = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = OrderTextBox.Size,
                FillColor = OrderTextBox.FillColor,
                Location = OrderTextBox.Location,
                Parent = mainBoxCopy,
                Name = "OrderTextBox2"
            };
            Guna.UI2.WinForms.Guna2PictureBox imageCopy = new Guna.UI2.WinForms.Guna2PictureBox
            {
                Size = OrderImage.Size,
                FillColor = OrderImage.FillColor,
                Location = OrderImage.Location,
                Parent = mainBoxCopy,
                Name = "OrderImage2"
            };
            // cloning text of sub-panels
            Guna.UI2.WinForms.Guna2HtmlLabel titleTextCopy = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Size = PcName.Size,
                Location = PcName.Location,
                Parent = titleBoxCopy,
                Font = PcName.Font,
                ForeColor = PcName.ForeColor,
                Text = PcName.Text,
                Name = "PcName2"
            };
            Guna.UI2.WinForms.Guna2HtmlLabel orderTextCopy = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Size = OrderText.Size,
                Location = OrderText.Location,
                Parent = listBoxCopy,
                Font = OrderText.Font,
                ForeColor = OrderText.ForeColor,
                Text = OrderText.Text,
                Name = "OrderText2"
            };

            // alter clone text test
            exampleText = "PC 03";
            titleTextCopy.Text = exampleText;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
