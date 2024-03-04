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
        private PC01Connection pc01Connection;
        private Button CloseChatButton;         //declare the CloseChatButton

        public ChatBox()
        {
            InitializeComponent();

            pc01Connection = new PC01Connection("127.0.0.1", 8000);         //just an example for while I work

            //initialize Open Chatbox button (FYI: guna2Button1 is the Open Chatbox button)
            guna2Button1.Text = "Open Chatbox";
            guna2Button1.Click += guna2Button1_Click;

            //initialize Close Chatbox button
            CloseChatButton = new Button
            {
                Text = "Close Chatbox",
                Size = guna2Button1.Size,       //match the size of the Open Chatbox button
                Location = guna2Button1.Location,       //place it in the same location too
                Font = new Font("Segoe UI", 14.142858f, FontStyle.Bold),        //match the font as the Open Chatbox button
                BackColor = SystemColors.ActiveBorder,      //set the background color aswell
                ForeColor = Color.Black,        //lastly, set the text color
                Visible = false     //initially hidden
            };
            this.Controls.Add(CloseChatButton);
            CloseChatButton.Click += CloseChatButton_Click;

            //initial visibility setup for chat components
            MessageTextBox.Visible = false;
            SendMessageButton.Visible = false;
            ChatTextBox.Visible = false;
        }

        private void ChatBox_Load(object sender, EventArgs e)
        {
            //my initialization code will go here
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (pc01Connection != null && !string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                string response = pc01Connection.SendMessage(MessageTextBox.Text);
                ChatTextBox.AppendText($"Server: {response}\n");
                MessageTextBox.Clear();     //this clears the message box after sending
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //show chat components
            MessageTextBox.Visible = true;
            SendMessageButton.Visible = true;
            ChatTextBox.Visible = true;

            //hide Open Chatbox button and show Close Chatbox button for better user experience
            guna2Button1.Visible = false;
            CloseChatButton.Visible = true;

            MessageTextBox.Focus();         //focus the message box for immediate typing, enchancing user experience
        }

        public bool ConnectToServer()       //method had to be public
        {
            if (!pc01Connection.Connect())
            {
                MessageBox.Show("Failed to connect to server.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                MessageBox.Show("Successfully connected to server.", "Connection Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }

        private void CloseChatButton_Click(object sender, EventArgs e)
        {
            //hide chat components
            MessageTextBox.Visible = false;
            SendMessageButton.Visible = false;
            ChatTextBox.Visible = false;

            //show Open Chatbox button and hide Close Chatbox button
            guna2Button1.Visible = true;
            CloseChatButton.Visible = false;

            //clear the chat history only if the user wishes to for enchanced user experience
            if (MessageBox.Show("Do you want to delete the chat history?", "Clear Chat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChatTextBox.Clear();
            }
        }

        //private void ConfirmOrderButton_Click(object sender, EventArgs e)
        //{
        //    //collect order details and send them to the server
        //    var orderDetails = GetOrderDetails();
        //    if (pc01Connection != null && !string.IsNullOrWhiteSpace(orderDetails))
        //    {
        //        string response = pc01Connection.SendMessage(orderDetails);
        //        MessageBox.Show($"Order response from server: {response}");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select at least one item before confirming the order.");
        //    }
        //}

        //private string GetOrderDetails()
        //{
        //    //retrieve the quantities from each numeric up-down control
        //    int espressoQuantity = (int)espressoNumericUpDown.Value;
        //    int americanoQuantity = (int)americanoNumericUpDown.Value;
        //    int latteQuantity = (int)latteNumericUpDown.Value;
        //    int cappuccinoQuantity = (int)cappuccinoNumericUpDown.Value;
        //    int macchiatoQuantity = (int)macchiatoNumericUpDown.Value;
        //    int cortadoQuantity = (int)cortadoNumericUpDown.Value;
        //    int filterCoffeeQuantity = (int)filterCoffeeNumericUpDown.Value;
        //    int teaQuantity = (int)teaNumericUpDown.Value;

        //    //build the order details string
        //    StringBuilder orderBuilder = new StringBuilder();
        //    orderBuilder.AppendFormat("Espresso: {0}, ", espressoQuantity);
        //    orderBuilder.AppendFormat("Americano: {0}, ", americanoQuantity);
        //    orderBuilder.AppendFormat("Latte: {0}, ", latteQuantity);
        //    orderBuilder.AppendFormat("Cappuccino: {0}, ", cappuccinoQuantity);
        //    orderBuilder.AppendFormat("Macchiato: {0}, ", macchiatoQuantity);
        //    orderBuilder.AppendFormat("Cortado: {0}, ", cortadoQuantity);
        //    orderBuilder.AppendFormat("Filter Coffee: {0}, ", filterCoffeeQuantity);
        //    orderBuilder.AppendFormat("Tea: {0}", teaQuantity);

        //    //return the order details
        //    return orderBuilder.ToString();
        //}

        private void ChatTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}