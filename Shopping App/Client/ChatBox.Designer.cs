namespace Client_PC01
{
    partial class ChatBox
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            SendMessageButton = new Button();
            MessageTextBox = new TextBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ChatTextBox = new TextBox();
            SuspendLayout();
            // 
            // SendMessageButton
            // 
            SendMessageButton.BackColor = SystemColors.ActiveBorder;
            SendMessageButton.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            SendMessageButton.Location = new Point(45, 242);
            SendMessageButton.Name = "SendMessageButton";
            SendMessageButton.Size = new Size(262, 66);
            SendMessageButton.TabIndex = 5;
            SendMessageButton.Text = "Send Message";
            SendMessageButton.UseVisualStyleBackColor = false;
            SendMessageButton.Click += SendMessageButton_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.BackColor = SystemColors.HighlightText;
            MessageTextBox.Location = new Point(514, 906);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(1199, 31);
            MessageTextBox.TabIndex = 6;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = SystemColors.ActiveBorder;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = SystemColors.AppWorkspace;
            guna2Button1.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Location = new Point(45, 112);
            guna2Button1.Margin = new Padding(2);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(262, 66);
            guna2Button1.TabIndex = 4;
            guna2Button1.Text = "Open Chatbox";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // ChatTextBox
            // 
            ChatTextBox.BackColor = SystemColors.InactiveCaption;
            ChatTextBox.Location = new Point(514, 65);
            ChatTextBox.Multiline = true;
            ChatTextBox.Name = "ChatTextBox";
            ChatTextBox.Size = new Size(1199, 849);
            ChatTextBox.TabIndex = 7;
            // 
            // ChatBox
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(SendMessageButton);
            Controls.Add(guna2Button1);
            Controls.Add(MessageTextBox);
            Controls.Add(ChatTextBox);
            Name = "ChatBox";
            Text = "ChatBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SendMessageButton;
        private TextBox MessageTextBox;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private TextBox ChatTextBox;
    }
}