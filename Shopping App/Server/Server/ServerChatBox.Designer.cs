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
            label2 = new Label();
            ServerRunningLabel = new Label();
            SendButton = new Button();
            BroadcastMessageTextBox = new TextBox();
            MessageDisplayListBox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(294, 23);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 12;
            label1.Text = "Received Messages:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(294, 420);
            label2.Name = "label2";
            label2.Size = new Size(205, 20);
            label2.TabIndex = 11;
            label2.Text = "Enter a Message to Broadcast";
            label2.Click += label2_Click;
            // 
            // ServerRunningLabel
            // 
            ServerRunningLabel.AutoSize = true;
            ServerRunningLabel.Location = new Point(12, 648);
            ServerRunningLabel.Name = "ServerRunningLabel";
            ServerRunningLabel.Size = new Size(108, 20);
            ServerRunningLabel.TabIndex = 10;
            ServerRunningLabel.Text = "Server Running";
            ServerRunningLabel.Click += ServerRunningLabel_Click;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(294, 476);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(80, 29);
            SendButton.TabIndex = 9;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // BroadcastMessageTextBox
            // 
            BroadcastMessageTextBox.Location = new Point(294, 443);
            BroadcastMessageTextBox.Name = "BroadcastMessageTextBox";
            BroadcastMessageTextBox.Size = new Size(316, 27);
            BroadcastMessageTextBox.TabIndex = 8;
            BroadcastMessageTextBox.TextChanged += BroadcastMessageTextBox_TextChanged;
            // 
            // MessageDisplayListBox
            // 
            MessageDisplayListBox.FormattingEnabled = true;
            MessageDisplayListBox.ItemHeight = 20;
            MessageDisplayListBox.Location = new Point(294, 58);
            MessageDisplayListBox.Name = "MessageDisplayListBox";
            MessageDisplayListBox.Size = new Size(651, 344);
            MessageDisplayListBox.TabIndex = 7;
            MessageDisplayListBox.SelectedIndexChanged += MessageDisplayListBox_SelectedIndexChanged;
            // 
            // ServerChatBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 677);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(ServerRunningLabel);
            Controls.Add(SendButton);
            Controls.Add(BroadcastMessageTextBox);
            Controls.Add(MessageDisplayListBox);
            Margin = new Padding(2);
            Name = "ServerChatBox";
            Text = "ServerChatBox";
            Load += ServerChatBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label ServerRunningLabel;
        private Button SendButton;
        private TextBox BroadcastMessageTextBox;
        private ListBox MessageDisplayListBox;
    }
}