using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_PC01
{
    //the ChatBoxToggler class provides a static method to toggle the visibility of chat-related UI components
    public class ChatBoxToggler
    {
        //the ToggleChat method changes the visibility of chat UI components based on the chat's current state
        public static void ToggleChat(
            Guna2Button btnToggleChat,          //button to toggle chat visibility
            ListBox lstChat,            //listBox displaying chat messages
            TextBox txtMessage,         //TextBox for entering messages
            Guna2Button btnSendMessage,         //button to send messages
            Guna2Button btnSendImage,           //button to send images
            Guna2Button btnClearChat,           //button to clear chat history
            Label lblInstructions)          //label displaying instructions
        {
            //determines whether the chat is currently open based on the visibility of the SendMessage button
            bool isChatOpen = btnSendMessage.Visible;

            if (!isChatOpen)
            {
                //if the chat is not currently open, it sets the chat components to be visible and hides the instructions
                lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = true;
                lblInstructions.Visible = false;            //hides instructional text as the chat is now open
                btnToggleChat.Text = "Close Chatbox";           //changes the toggle button text to indicate the chat can be closed
            }
            else
            {
                //if the chat is open, prompts the user with a decision to clear the chat history before closing
                var result = MessageBox.Show("Do you want to clear chat history?", "Clear History", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //clears the chat history if the user chooses yes
                    lstChat.Items.Clear();
                }

                //sets chat components to be invisible and shows the instructions again, effectively closing the chat
                lstChat.Visible = txtMessage.Visible = btnSendMessage.Visible = btnSendImage.Visible = btnClearChat.Visible = false;
                lblInstructions.Visible = true;         //shows instructional text again
                btnToggleChat.Text = "Open Chatbox";            //changes the toggle button text to indicate the chat can be opened
            }
        }
    }
}