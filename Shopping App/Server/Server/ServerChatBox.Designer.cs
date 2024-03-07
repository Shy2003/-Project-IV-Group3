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
            label1 = new Label();
            RecievedMessages = new ListBox();
            label3 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 648);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Server Running...";
            label1.Click += label1_Click;
            // 
            // RecievedMessages
            // 
            RecievedMessages.FormattingEnabled = true;
            RecievedMessages.ItemHeight = 20;
            RecievedMessages.Location = new Point(135, 74);
            RecievedMessages.Name = "RecievedMessages";
            RecievedMessages.Size = new Size(840, 464);
            RecievedMessages.TabIndex = 1;
            RecievedMessages.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 541);
            label3.Name = "label3";
            label3.Size = new Size(205, 20);
            label3.TabIndex = 3;
            label3.Text = "Enter a Message to Broadcast";
            label3.Click += label3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 564);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(310, 27);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(135, 597);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ServerChatBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 677);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(RecievedMessages);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "ServerChatBox";
            Text = "ServerChatBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox RecievedMessages;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
    }
}