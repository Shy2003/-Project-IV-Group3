using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client_PC01
{
    public partial class OrderPageForm : Form
    {
        // Constructor
        public OrderPageForm()
        {
            InitializeComponent();
        }

        // Method to initialize form components
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPageForm));
            headerLabel = new Label();
            dishLabel1 = new Label();
            dishLabel2 = new Label();
            dishLabel3 = new Label();
            dishLabel4 = new Label();
            dishLabel5 = new Label();
            dishLabel6 = new Label();
            dishLabel7 = new Label();
            dishLabel8 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            numericUpDown7 = new NumericUpDown();
            numericUpDown8 = new NumericUpDown();
            confirmOrderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
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
            // 
            // dishLabel1
            // 
            dishLabel1.AutoSize = true;
            dishLabel1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel1.Location = new Point(50, 120);
            dishLabel1.Name = "dishLabel1";
            dishLabel1.Size = new Size(77, 19);
            dishLabel1.TabIndex = 1;
            dishLabel1.Text = "Espresso";
            // 
            // dishLabel2
            // 
            dishLabel2.AutoSize = true;
            dishLabel2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel2.Location = new Point(216, 120);
            dishLabel2.Name = "dishLabel2";
            dishLabel2.Size = new Size(88, 19);
            dishLabel2.TabIndex = 2;
            dishLabel2.Text = "Americano";
            // 
            // dishLabel3
            // 
            dishLabel3.AutoSize = true;
            dishLabel3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel3.Location = new Point(390, 120);
            dishLabel3.Name = "dishLabel3";
            dishLabel3.Size = new Size(44, 19);
            dishLabel3.TabIndex = 3;
            dishLabel3.Text = "Latte";
            // 
            // dishLabel4
            // 
            dishLabel4.AutoSize = true;
            dishLabel4.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel4.Location = new Point(577, 120);
            dishLabel4.Name = "dishLabel4";
            dishLabel4.Size = new Size(97, 19);
            dishLabel4.TabIndex = 4;
            dishLabel4.Text = "Cappuccino";
            // 
            // dishLabel5
            // 
            dishLabel5.AutoSize = true;
            dishLabel5.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel5.Location = new Point(50, 305);
            dishLabel5.Name = "dishLabel5";
            dishLabel5.Size = new Size(84, 19);
            dishLabel5.TabIndex = 5;
            dishLabel5.Text = "Macchiato";
            // 
            // dishLabel6
            // 
            dishLabel6.AutoSize = true;
            dishLabel6.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel6.Location = new Point(216, 305);
            dishLabel6.Name = "dishLabel6";
            dishLabel6.Size = new Size(67, 19);
            dishLabel6.TabIndex = 6;
            dishLabel6.Text = "Cortado";
            // 
            // dishLabel7
            // 
            dishLabel7.AutoSize = true;
            dishLabel7.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel7.Location = new Point(390, 305);
            dishLabel7.Name = "dishLabel7";
            dishLabel7.Size = new Size(99, 19);
            dishLabel7.TabIndex = 7;
            dishLabel7.Text = "Filter Coffee";
            // 
            // dishLabel8
            // 
            dishLabel8.AutoSize = true;
            dishLabel8.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dishLabel8.Location = new Point(577, 305);
            dishLabel8.Name = "dishLabel8";
            dishLabel8.Size = new Size(34, 19);
            dishLabel8.TabIndex = 8;
            dishLabel8.Text = "Tea";
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
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(577, 152);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 100);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(50, 337);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(100, 100);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(216, 337);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(100, 100);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 14;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(390, 337);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(100, 100);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 15;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(577, 337);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(100, 100);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 16;
            pictureBox8.TabStop = false;
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
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(577, 258);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(120, 27);
            numericUpDown4.TabIndex = 20;
            numericUpDown4.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(50, 443);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(120, 27);
            numericUpDown5.TabIndex = 21;
            numericUpDown5.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(216, 443);
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(120, 27);
            numericUpDown6.TabIndex = 22;
            numericUpDown6.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(390, 443);
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(120, 27);
            numericUpDown7.TabIndex = 23;
            numericUpDown7.ValueChanged += numericUpDown_ValueChanged;
            // 
            // numericUpDown8
            // 
            numericUpDown8.Location = new Point(577, 443);
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(120, 27);
            numericUpDown8.TabIndex = 24;
            numericUpDown8.ValueChanged += numericUpDown_ValueChanged;
            // 
            // confirmOrderButton
            // 
            confirmOrderButton.BackColor = Color.Green;
            confirmOrderButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            confirmOrderButton.ForeColor = Color.White;
            confirmOrderButton.Location = new Point(282, 498);
            confirmOrderButton.Name = "confirmOrderButton";
            confirmOrderButton.Size = new Size(150, 50);
            confirmOrderButton.TabIndex = 25;
            confirmOrderButton.Text = "Confirm Order";
            confirmOrderButton.UseVisualStyleBackColor = false;
            confirmOrderButton.Click += ConfirmOrderButton_Click;
            // 
            // OrderPageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 625);
            Controls.Add(numericUpDown1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown7);
            Controls.Add(numericUpDown8);
            Controls.Add(headerLabel);
            Controls.Add(dishLabel1);
            Controls.Add(dishLabel2);
            Controls.Add(dishLabel3);
            Controls.Add(dishLabel4);
            Controls.Add(dishLabel5);
            Controls.Add(dishLabel6);
            Controls.Add(dishLabel7);
            Controls.Add(dishLabel8);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox8);
            Controls.Add(confirmOrderButton);
            Margin = new Padding(2);
            Name = "OrderPageForm";
            Text = "Order Page";
            Load += OrderPageForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label headerLabel;
        private Label dishLabel1;
        private Label dishLabel2;
        private Label dishLabel3;
        private Label dishLabel4;
        private Label dishLabel5;
        private Label dishLabel6;
        private Label dishLabel7;
        private Label dishLabel8;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private Button confirmOrderButton;
        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            // Add your logic here for confirming the order
            MessageBox.Show("Order Confirmed!");
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Get the sender control which triggered the event
            var numericUpDown = sender as NumericUpDown;

            // Check if the sender control is not null
            if (numericUpDown != null)
            {

                int value = (int)numericUpDown.Value;


            }
        }

        private void OrderPageForm_Load(object sender, EventArgs e)
        {

        }
    }
}