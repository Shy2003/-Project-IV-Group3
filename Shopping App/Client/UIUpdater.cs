using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Client_PC01
{
    //this static class provides methods to update the UI with new messages and images
    //it ensures thread safety when updating UI elements from non-UI threads
    public static class UIUpdater
    {
        //updates the chat interface to display a new text message
        public static void DisplayMessage(ListBox lstChat, string message)
        {
            //checks if the method is called from a thread other than the UI thread
            if (lstChat.InvokeRequired)
            {
                //if so, it uses Invoke to rerun DisplayMessage on the UI thread
                lstChat.Invoke(new Action(() => DisplayMessage(lstChat, message)));
            }
            else
            {
                //if the current thread is the UI thread, it directly adds the message to the chat list
                lstChat.Items.Add(message);
            }
        }

        //updates the chat interface to display a received image
        public static void DisplayReceivedImage(PictureBox pictureBoxReceived, byte[] imageData)
        {
            //checks if the method is called from a thread other than the UI thread
            if (pictureBoxReceived.InvokeRequired)
            {
                //if so, it uses Invoke to rerun DisplayReceivedImage on the UI thread
                pictureBoxReceived.Invoke(new Action(() => DisplayReceivedImage(pictureBoxReceived, imageData)));
            }
            else
            {
                //if the current thread is the UI thread, it processes the image data and updates the PictureBox
                using (var ms = new MemoryStream(imageData))
                {
                    var image = Image.FromStream(ms);
                    pictureBoxReceived.Image = image;
                    //makes the PictureBox visible to show the new image
                    pictureBoxReceived.Visible = true;
                }
            }
        }
    }
}