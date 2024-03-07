using Guna.UI2.WinForms;
using System;
using System.CodeDom;
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
            // test of creating three orders
            setOrderData(PcName, OrderText, OrderImage, "PC 01", "Espresso x1", "Untitled.png");
            CloneOrderItem("PC 02", "Tea x2", "Untitled.png", 1);
            CloneOrderItem("PC 04", "Filtered Coffee x1", "Untitled.png", 2);
        }

        // in case of panel being picture box
        private Guna2PictureBox ClonePanel(Guna2PictureBox ogPanel, Guna2Panel parentPanel, int PanelOffset)
        {
            if (PanelOffset == 0)
            {
                PanelOffset = ogPanel.Location.Y;
            }
            Guna2PictureBox newPanel = new()
            {
                Size = ogPanel.Size,
                Location = new Point(ogPanel.Location.X, PanelOffset),
                Parent = parentPanel
            };
            return newPanel;
        }

        // In case of parent panel being container
        private Guna2Panel ClonePanel(Guna2Panel ogPanel, Guna2ContainerControl parentPanel, int PanelOffset)
        {
            if (PanelOffset == 0){
                PanelOffset = ogPanel.Location.Y;
            }
            Guna2Panel newPanel = new()
            {
                Size = ogPanel.Size,
                FillColor = ogPanel.FillColor,
                Location = new Point(ogPanel.Location.X, PanelOffset),
                Parent = parentPanel
            };
            return newPanel;
        }

        // default case
        private Guna2Panel ClonePanel(Guna2Panel ogPanel, Guna2Panel parentPanel, int PanelOffset)
        {
            if (PanelOffset == 0)
            {
                PanelOffset = ogPanel.Location.Y;
            }
            Guna2Panel newPanel = new()
            {
                Size = ogPanel.Size,
                FillColor = ogPanel.FillColor,
                Location = new Point(ogPanel.Location.X, PanelOffset),
                Parent = parentPanel
            };
            return newPanel;
        }

        // slightly different clone for labels
        private Guna2HtmlLabel CloneLabel(Guna2HtmlLabel ogLabel, Guna2Panel parentPanel, int LabelOffset)
        {
            if (LabelOffset == 0)
            {
                LabelOffset = ogLabel.Location.Y;
            }
            Guna2HtmlLabel newLabel = new()
            {
                Size = ogLabel.Size,
                Location = new Point(ogLabel.Location.X, LabelOffset),
                Parent = parentPanel,
                Font = ogLabel.Font,
                ForeColor = ogLabel.ForeColor,
            };
            return newLabel;
        }

        // create a new order item - should be called whenever a new order is recieved from client
        // may need to alter it once the client is integrated
        private void CloneOrderItem(String pcName, String orderItems, String orderImage, int iteration) {
            // cloning order panel test
            int BasePanelOffset = (OrderBox.Location.Y + OrderBox.Height + 15) * iteration;
            int noOffset = 0;
            Guna2Panel mainBoxCopy = ClonePanel(OrderBox, OrderItems, BasePanelOffset);

            // cloning children of main panel
            Guna2Panel titleBoxCopy = ClonePanel(PcNameBox, mainBoxCopy, noOffset);
            Guna2Panel listBoxCopy = ClonePanel(OrderTextBox, mainBoxCopy, noOffset);
            Guna2PictureBox imageCopy = ClonePanel(OrderImage, mainBoxCopy, noOffset);

            // cloning text of sub-panels
            Guna2HtmlLabel titleTextCopy = CloneLabel(PcName, titleBoxCopy, noOffset);
            Guna2HtmlLabel orderTextCopy = CloneLabel(OrderText, listBoxCopy, noOffset);

            setOrderData(titleTextCopy, orderTextCopy, imageCopy, pcName, orderItems, orderImage);
        }

        private void setOrderData(Guna2HtmlLabel titleUI, Guna2HtmlLabel orderUI, Guna2PictureBox imageUI, String pcName, String orderItems, String orderImage)
        {
            titleUI.Text = pcName;
            orderUI.Text = orderItems;
            imageUI.ImageLocation = orderImage;
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
