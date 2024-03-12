using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Server
{
    public class UIUpdater
    {
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label senderLabel;
        private PictureBox pictureBox;

        public UIUpdater(System.Windows.Forms.TextBox textBox, System.Windows.Forms.Label senderLabel, PictureBox pictureBox)
        {
            this.textBox = textBox;
            this.senderLabel = senderLabel;
            this.pictureBox = pictureBox;
        }

        // Updates the sender label with the provided name
        public void UpdateSender(string senderName)
        {
            if (senderLabel.InvokeRequired)
            {
                senderLabel.Invoke((MethodInvoker)delegate
                {
                    senderLabel.Text = senderName;
                });
            }
            else
            {
                senderLabel.Text = senderName;
            }
        }

        // Updates the UI with received text message
        public void UpdateReceivedTextMessage(string message)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke((MethodInvoker)delegate { textBox.AppendText(message + Environment.NewLine); });
            }
            else
            {
                textBox.AppendText(message + Environment.NewLine);
            }
        }

        // Updates the UI with received image
        public void UpdateReceivedImage(byte[] imageData)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke((MethodInvoker)delegate { DisplayImage(imageData); });
            }
            else
            {
                DisplayImage(imageData);
            }
        }

        // Helper method to display image from byte array
        private void DisplayImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }
    }
}



