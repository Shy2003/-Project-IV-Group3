using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Add this to use the Windows Forms controls
using Guna.UI2.WinForms;

namespace Server
{
    internal class ServerUI
    {
        public static void ToggleChatVisibility(Guna2Button btnToggleChat, ListBox lstChat, TextBox txtMessage, Guna2Button btnSendMessage, Guna2Button btnSendImage, Guna2Button btnClearChat, Label lblInstructions)
        {
            bool isChatOpen = btnSendMessage.Visible;

            if (!isChatOpen)
            {
                lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = true;
                lblInstructions.Visible = false;
                btnToggleChat.Text = "Close Chatbox";
            }
            else
            {
                var result = MessageBox.Show("Do you want to clear chat history?", "Clear History", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lstChat.Items.Clear();
                }

                lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;
                lblInstructions.Visible = true;
                btnToggleChat.Text = "Open Chatbox";
            }
        }
    }
}
