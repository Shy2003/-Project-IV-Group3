using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client_PC01
{
    public partial class OrderPageForm : Form
    {
        // Constructor with parameter for PC number
        public string pcNumber;
        private Button clearButton;
        private PC01Connection connection;

        public OrderPageForm(string pcNumber)
    {
        InitializeComponent();
        this.pcNumber = pcNumber;
    }

        // Constructor
        public OrderPageForm()
        {
            InitializeComponent();
            connection = new PC01Connection("127.0.0.1", 13000);
        }

        // Method to initialize form components
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPageForm));
            headerLabel = new Label();
            dishLabel1 = new Label();
            dishLabel2 = new Label();
            dishLabel3 = new Label();
            dishLabel5 = new Label();
            dishLabel6 = new Label();
            dishLabel7 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            numericUpDown7 = new NumericUpDown();
            confirmOrderButton = new Button();
            priceLabel1 = new Label();
            priceLabel2 = new Label();
            priceLabel3 = new Label();
            priceLabel5 = new Label();
            priceLabel6 = new Label();
            priceLabel7 = new Label();
            orderDetailsGroupBox = new GroupBox();
            orderDetailsListBox = new ListBox();
            clearButton = new Button();
            calculateTotalButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            orderDetailsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.BackColor = Color.FromArgb(255, 255, 192);
            headerLabel.BorderStyle = BorderStyle.FixedSingle;
            headerLabel.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            headerLabel.ForeColor = Color.DarkRed;
            headerLabel.Location = new Point(282, 18);
            headerLabel.Margin = new Padding(2, 0, 2, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Padding = new Padding(5);
            headerLabel.Size = new Size(299, 44);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "ORDER YOUR FOOD";
            headerLabel.Click += headerLabel_Click;
            // 
            // dishLabel1
            // 
            dishLabel1.AutoSize = true;
            dishLabel1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel1.Location = new Point(50, 130);
            dishLabel1.Name = "dishLabel1";
            dishLabel1.Size = new Size(77, 19);
            dishLabel1.TabIndex = 1;
            dishLabel1.Text = "Espresso";
            // 
            // dishLabel2
            // 
            dishLabel2.AutoSize = true;
            dishLabel2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel2.Location = new Point(216, 130);
            dishLabel2.Name = "dishLabel2";
            dishLabel2.Size = new Size(88, 19);
            dishLabel2.TabIndex = 2;
            dishLabel2.Text = "Americano";
            // 
            // dishLabel3
            // 
            dishLabel3.AutoSize = true;
            dishLabel3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel3.Location = new Point(390, 130);
            dishLabel3.Name = "dishLabel3";
            dishLabel3.Size = new Size(44, 19);
            dishLabel3.TabIndex = 3;
            dishLabel3.Text = "Latte";
            // 
            // dishLabel5
            // 
            dishLabel5.AutoSize = true;
            dishLabel5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel5.Location = new Point(50, 338);
            dishLabel5.Name = "dishLabel5";
            dishLabel5.Size = new Size(84, 19);
            dishLabel5.TabIndex = 5;
            dishLabel5.Text = "Macchiato";
            // 
            // dishLabel6
            // 
            dishLabel6.AutoSize = true;
            dishLabel6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel6.Location = new Point(216, 338);
            dishLabel6.Name = "dishLabel6";
            dishLabel6.Size = new Size(67, 19);
            dishLabel6.TabIndex = 6;
            dishLabel6.Text = "Cortado";
            // 
            // dishLabel7
            // 
            dishLabel7.AutoSize = true;
            dishLabel7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel7.Location = new Point(390, 338);
            dishLabel7.Name = "dishLabel7";
            dishLabel7.Size = new Size(99, 19);
            dishLabel7.TabIndex = 7;
            dishLabel7.Text = "Filter Coffee";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(50, 152);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(216, 152);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(390, 152);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 100);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(50, 360);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(100, 100);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(216, 360);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(100, 100);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 14;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(390, 360);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(100, 100);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 15;
            pictureBox7.TabStop = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(50, 258);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 27);
            numericUpDown1.TabIndex = 17;
            numericUpDown1.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(216, 258);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 27);
            numericUpDown2.TabIndex = 18;
            numericUpDown2.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(390, 258);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 27);
            numericUpDown3.TabIndex = 19;
            numericUpDown3.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(50, 466);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(120, 27);
            numericUpDown5.TabIndex = 21;
            numericUpDown5.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(216, 466);
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(120, 27);
            numericUpDown6.TabIndex = 22;
            numericUpDown6.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(390, 466);
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(120, 27);
            numericUpDown7.TabIndex = 23;
            numericUpDown7.ValueChanged += numericUpDown_ValueChanged;
            // 
            // confirmOrderButton
            // 
            confirmOrderButton.BackColor = Color.Green;
            confirmOrderButton.Enabled = false;
            confirmOrderButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            confirmOrderButton.ForeColor = Color.White;
            confirmOrderButton.Location = new Point(282, 546);
            confirmOrderButton.Name = "confirmOrderButton";
            confirmOrderButton.Size = new Size(150, 50);
            confirmOrderButton.TabIndex = 25;
            confirmOrderButton.Text = "Confirm Order";
            confirmOrderButton.UseVisualStyleBackColor = false;
            confirmOrderButton.Click += ConfirmOrderButton_Click;
            // 
            // priceLabel1
            // 
            priceLabel1.Location = new Point(50, 288);
            priceLabel1.Name = "priceLabel1";
            priceLabel1.Size = new Size(100, 23);
            priceLabel1.TabIndex = 0;
            priceLabel1.Text = "$12";
            // 
            // priceLabel2
            // 
            priceLabel2.Location = new Point(216, 288);
            priceLabel2.Name = "priceLabel2";
            priceLabel2.Size = new Size(100, 23);
            priceLabel2.TabIndex = 1;
            priceLabel2.Text = "$10";
            // 
            // priceLabel3
            // 
            priceLabel3.Location = new Point(390, 288);
            priceLabel3.Name = "priceLabel3";
            priceLabel3.Size = new Size(100, 23);
            priceLabel3.TabIndex = 2;
            priceLabel3.Text = "$8";
            // 
            // priceLabel5
            // 
            priceLabel5.Location = new Point(50, 496);
            priceLabel5.Name = "priceLabel5";
            priceLabel5.Size = new Size(100, 23);
            priceLabel5.TabIndex = 4;
            priceLabel5.Text = "$9";
            // 
            // priceLabel6
            // 
            priceLabel6.Location = new Point(216, 496);
            priceLabel6.Name = "priceLabel6";
            priceLabel6.Size = new Size(100, 23);
            priceLabel6.TabIndex = 5;
            priceLabel6.Text = "$11";
            // 
            // priceLabel7
            // 
            priceLabel7.Location = new Point(390, 496);
            priceLabel7.Name = "priceLabel7";
            priceLabel7.Size = new Size(100, 23);
            priceLabel7.TabIndex = 6;
            priceLabel7.Text = "$7";
            // 
            // orderDetailsGroupBox
            // 
            orderDetailsGroupBox.Controls.Add(orderDetailsListBox);
            orderDetailsGroupBox.Controls.Add(clearButton);
            orderDetailsGroupBox.Controls.Add(calculateTotalButton);
            orderDetailsGroupBox.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            orderDetailsGroupBox.ForeColor = Color.DarkRed;
            orderDetailsGroupBox.Location = new Point(600, 77);
            orderDetailsGroupBox.Name = "orderDetailsGroupBox";
            orderDetailsGroupBox.Size = new Size(300, 502);
            orderDetailsGroupBox.TabIndex = 0;
            orderDetailsGroupBox.TabStop = false;
            orderDetailsGroupBox.Text = "ORDER DETAILS";
            // 
            // orderDetailsListBox
            // 
            orderDetailsListBox.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            orderDetailsListBox.HorizontalScrollbar = true;
            orderDetailsListBox.ItemHeight = 19;
            orderDetailsListBox.Location = new Point(0, 102);
            orderDetailsListBox.Name = "orderDetailsListBox";
            orderDetailsListBox.Size = new Size(250, 346);
            orderDetailsListBox.TabIndex = 0;
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.Red;
            clearButton.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            clearButton.ForeColor = Color.White;
            clearButton.Location = new Point(200, 460);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(80, 30);
            clearButton.TabIndex = 1;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += ClearButton_Click;
            // 
            // calculateTotalButton
            // 
            calculateTotalButton.BackColor = Color.Blue;
            calculateTotalButton.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            calculateTotalButton.ForeColor = Color.White;
            calculateTotalButton.Location = new Point(100, 460);
            calculateTotalButton.Name = "calculateTotalButton";
            calculateTotalButton.Size = new Size(80, 30);
            calculateTotalButton.TabIndex = 2;
            calculateTotalButton.Text = "Calculate";
            calculateTotalButton.UseVisualStyleBackColor = false;
            calculateTotalButton.Click += CalculateTotalButton_Click;
            // 
            // OrderPageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 625);
            Controls.Add(orderDetailsGroupBox);
            Controls.Add(numericUpDown1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown7);
            Controls.Add(headerLabel);
            Controls.Add(dishLabel1);
            Controls.Add(dishLabel2);
            Controls.Add(dishLabel3);
            Controls.Add(dishLabel5);
            Controls.Add(dishLabel6);
            Controls.Add(dishLabel7);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox7);
            Controls.Add(confirmOrderButton);
            Controls.Add(priceLabel1);
            Controls.Add(priceLabel2);
            Controls.Add(priceLabel3);
            Controls.Add(priceLabel5);
            Controls.Add(priceLabel6);
            Controls.Add(priceLabel7);
            Margin = new Padding(2);
            Name = "OrderPageForm";
            Text = "Order Page";
            Load += OrderPageForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            orderDetailsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        public Label headerLabel;

        public Label dishLabel1;
        public Label dishLabel2;
        public Label dishLabel3;
        public Label dishLabel5;
        public Label dishLabel6;
        public Label dishLabel7;

        public PictureBox pictureBox1;
        public PictureBox pictureBox2;
        public PictureBox pictureBox3;
        public PictureBox pictureBox5;
        public PictureBox pictureBox6;
        public PictureBox pictureBox7;

        public NumericUpDown numericUpDown1;
        public NumericUpDown numericUpDown2;
        public NumericUpDown numericUpDown3;
        public NumericUpDown numericUpDown5;
        public NumericUpDown numericUpDown6;
        public NumericUpDown numericUpDown7;

        public Label priceLabel1;
        public Label priceLabel2;
        public Label priceLabel3;
        public Label priceLabel5;
        public Label priceLabel6;
        public Label priceLabel7;

        public GroupBox orderDetailsGroupBox;

        public ListBox orderDetailsListBox;

        public Button confirmOrderButton;

        // Add a field to track the state of the confirmation button
        public bool isOrderConfirmed = false;

        // Add a calculateTotalButton field to your form
        public Button calculateTotalButton;

        // Event handler for the Calculate Total button
        public void CalculateTotalButton_Click(object sender, EventArgs e)
        {
            int total = 0;

            // Loop through the items in the order details list and calculate the total price
            foreach (var item in orderDetailsListBox.Items)
            {
                string itemString = item.ToString();
                int startIndex = itemString.LastIndexOf('$') + 1;
                int endIndex = itemString.Length;
                int price = int.Parse(itemString.Substring(startIndex, endIndex - startIndex));

                total += price;
            }

            // Display the total price
            MessageBox.Show($"Total Price: ${total}");
        }

        // Handle the click event of the clear button
        public void ClearButton_Click(object sender, EventArgs e)
        {
            // Retrieve the order details listbox
            GroupBox orderDetailsGroupBox = Controls.Find("orderDetailsGroupBox", true).FirstOrDefault() as GroupBox;
            ListBox orderDetailsListBox = orderDetailsGroupBox.Controls.OfType<ListBox>().FirstOrDefault();

            // Clear one item from the order details list
            if (orderDetailsListBox != null && orderDetailsListBox.Items.Count > 0)
            {
                orderDetailsListBox.Items.RemoveAt(orderDetailsListBox.Items.Count - 1);
            }
        }

        public void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            if (!isOrderConfirmed)
            {
                // Retrieve the order details listbox
                GroupBox orderDetailsGroupBox = Controls.Find("orderDetailsGroupBox", true).FirstOrDefault() as GroupBox;
                ListBox orderDetailsListBox = orderDetailsGroupBox.Controls.OfType<ListBox>().FirstOrDefault();

                // Check if orderDetailsListBox is null
                if (orderDetailsListBox != null)
                {
                    // Gather order details from the orderDetailsListBox
                    List<string> orderDetails = new List<string>();
                    foreach (var item in orderDetailsListBox.Items)
                    {
                        orderDetails.Add(item.ToString());
                    }

                    // Convert the list of order details into a single string
                    string orderDetailsString = string.Join(", ", orderDetails);

                    // Send the order details string to the server
                    Client client = new Client();
                    client.SendOrder(orderDetailsString);

                    // Add your logic here for confirming the order
                    MessageBox.Show("Order Confirmed!");
                    isOrderConfirmed = true; // Set the order confirmation state
                }
                else
                {
                    // Handle the case where orderDetailsListBox is null
                    MessageBox.Show("Error: Unable to retrieve order details.");
                }
            }
        }




        public void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Get the sender control which triggered the event
            var numericUpDown = sender as NumericUpDown;

            // Check if the sender control is not null and the value is greater than 0
            if (numericUpDown != null && numericUpDown.Value > 0)
            {
                int value = (int)numericUpDown.Value;

                // Calculate the total price based on the quantity
                int totalPrice = value * GetPrice((Control)numericUpDown);

                // Update the order details list
                UpdateOrderDetailsList((Control)numericUpDown, value, totalPrice);

                // Enable the confirmOrderButton
                confirmOrderButton.Enabled = true;
            }
        }

        // Helper method to get the price of an item
        public int GetPrice(Control control)
        {
            // Retrieve the corresponding price label based on the control's name
            string priceLabelName = "priceLabel" + control.Name.Substring(control.Name.Length - 1);
            Label priceLabel = Controls.Find(priceLabelName, true).FirstOrDefault() as Label;

            if (priceLabel != null)
            {
                // Extract the price value from the label's text
                string priceText = priceLabel.Text.Replace("$", "");
                return int.Parse(priceText);
            }

            return 0; // Default to 0 if price label not found
        }

        // Helper method to update the order details list
        public void UpdateOrderDetailsList(Control control, int quantity, int totalPrice)
        {
            // Retrieve the corresponding dish label based on the control's name
            string dishLabelName = "dishLabel" + control.Name.Substring(control.Name.Length - 1);
            Label dishLabel = Controls.Find(dishLabelName, true).FirstOrDefault() as Label;

            // Retrieve the order details listbox
            GroupBox orderDetailsGroupBox = Controls.Find("orderDetailsGroupBox", true).FirstOrDefault() as GroupBox;
            ListBox orderDetailsListBox = orderDetailsGroupBox.Controls.OfType<ListBox>().FirstOrDefault();

            // Update the order details list with the selected item, quantity, and total price
            if (orderDetailsListBox != null && dishLabel != null)
            {
                string orderDetail = $"{quantity} x {dishLabel.Text} - Total Price: ${totalPrice}";
                orderDetailsListBox.Items.Add(orderDetail);
            }
        }
        public void OrderPageForm_Load(object sender, EventArgs e)
        {

        }

        public void headerLabel_Click(object sender, EventArgs e)
        {

        }

        public void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }

    public class Client
    {
        public void SendOrder(string orderDetails)
        {
            string serverIpAddress = "127.0.0.1"; // Server running on the same machine
            int serverPort = 8888; // Port on which the server is listening

            // Establish a connection with the server
            using (TcpClient client = new TcpClient(serverIpAddress, serverPort))
            {
                // Get the network stream
                using (NetworkStream stream = client.GetStream())
                {
                    // Convert the order details to bytes
                    byte[] data = Encoding.ASCII.GetBytes(orderDetails);

                    // Send the data to the server
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Order sent to server: " + orderDetails);
                }
            }
        }
    }
}



/*  class Program
  {
      static void Main(string[] args)
      {
          // Client sends the order to the server
          Client client = new Client();
          client.SendOrder("PC 01, Espresso x2, Latte x1");
      }
  }
}*/






