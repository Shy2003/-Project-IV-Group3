namespace Server
{
    partial class ServerChatBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button2 = new Button();
            textBox2 = new TextBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(925, 181);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 29;
            button2.Text = "Send";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(925, 147);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(286, 27);
            textBox2.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(925, 121);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 27;
            label5.Text = "Enter reply to Client";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Silver;
            pictureBox1.Location = new Point(251, 292);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(562, 319);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(251, 246);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 25;
            label4.Text = "Recieved Picture:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(251, 181);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(553, 27);
            textBox1.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(251, 147);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 23;
            label3.Text = "Recieved Message";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 66);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 22;
            label2.Text = "PC Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(251, 66);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 21;
            label1.Text = "Sender:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 0, 0);
            button1.Location = new Point(54, 129);
            button1.Name = "button1";
            button1.Size = new Size(130, 57);
            button1.TabIndex = 20;
            button1.Text = "Close Chatbox";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // ServerChatBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 677);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "ServerChatBox";
            Text = "ServerChatBox";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private TextBox textBox2;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
    }
}