//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.IO;

//namespace Client_PC01
//{
//    //this static class is responsible for handling the communication with the server,
//    //specifically for sending text messages and images
//    public static class ServerCommunicationHandler
//    {
//        //sends a text message to the server and updates the chat UI to display the sent message
//        public static void SendMessage(
//            PC01Connection client,
//            string message,
//            TextBox txtMessage,
//            Action<string> displayMessage)
//        {
//            //checks if the message is not empty
//            if (!string.IsNullOrEmpty(message))
//            {
//                //checks if the client is not connected
//                if (client == null || !client.IsConnected)
//                {
//                    //attempts to connect to the server if not already connected
//                    client = new PC01Connection("127.0.0.1", 13000);
//                    if (!client.Connect())
//                    {
//                        //if the connection attempt fails, show a message and return
//                        MessageBox.Show("Failed to connect to the server.");
//                        return;
//                    }
//                }

//                //sends the message to the server
//                client.SendMessage(message);
//                //invokes the displayMessage action to update the UI with the sent message
//                displayMessage?.Invoke("Me: " + message);
//                //clears the text box after sending the message
//                txtMessage.Clear();
//            }
//        }

//        //opens a dialog for the user to select an image to send, then sends the selected image to the server
//        public static void SendImage(
//            PC01Connection client,
//            Action<string> displayMessage)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog
//            {
//                Filter = "Image Files|*.jpg;*.jpeg;*.png;"          //filters to only show image files
//            };
//            //shows the OpenFileDialog and checks if the user selected a file
//            if (openFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                string imagePath = openFileDialog.FileName;         //gets the path of the selected image

//                //checks if the client is not connected
//                if (client == null || !client.IsConnected)
//                {
//                    //attempts to connect to the server if not already connected
//                    client = new PC01Connection("127.0.0.1", 13000);
//                    if (!client.Connect())
//                    {
//                        //if the connection attempt fails, show a message and return
//                        MessageBox.Show("Failed to connect to the server.");
//                        return;
//                    }
//                }

//                //sends the image to the server
//                client.SendImage(imagePath);
//                //invokes the displayMessage action to update the UI indicating an image has been sent
//                displayMessage?.Invoke("Me: [Image sent]");
//            }
//        }
//    }
//}