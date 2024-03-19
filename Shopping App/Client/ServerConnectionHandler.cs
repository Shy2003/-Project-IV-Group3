//using Guna.UI2.WinForms;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Client_PC01
//{
//    //this static class is responsible for handling server connections and disconnections
//    public static class ServerConnectionHandler
//    {
//        //attempts to establish a connection to the server using the specified IP address and port
//        //it also configures UI elements based on the connection status and subscribes to message and image reception events
//        public static PC01Connection ConnectToServer(
//            string ipAddress, int port,
//            Guna2Button connectButton, Guna2Button disconnectButton,
//            Action<string> onTextMessageReceived, Action<byte[]> onImageReceived)
//        {
//            //create a new connection instance to the server
//            PC01Connection client = new PC01Connection(ipAddress, port);
//            if (client.Connect())
//            {
//                //display a message box indicating successful connection
//                MessageBox.Show("Connected to server.");
//                //hide the connect button and show the disconnect button to reflect the current connection status
//                connectButton.Visible = false;
//                disconnectButton.Visible = true;

//                //subscribe to events for receiving text messages and images from the server,
//                //using the provided delegates to handle the received data
//                client.TextMessageReceived += (message) => onTextMessageReceived?.Invoke(message);
//                client.ImageReceived += (imageData) => onImageReceived?.Invoke(imageData);
//            }
//            else
//            {
//                //Error Handling: if the connection attempt fails, display a message box indicating the failure
//                MessageBox.Show("Failed to connect to the server.");
//            }
//            return client;              //return the connection instance.
//        }

//        //disconnects from the server and updates the UI elements to reflect the disconnection
//        public static void DisconnectFromServer(
//            PC01Connection client,
//            Guna2Button connectButton,
//            Guna2Button disconnectButton)
//        {
//            if (client != null)             //check if there's an existing connection to disconnect from
//            {
//                client.Disconnect();                //disconnect the client from the server
//                //display a message box indicating that the client has been disconnected
//                MessageBox.Show("Disconnected from server.");
//                //show the connect button and hide the disconnect button to reflect the current connection status
//                connectButton.Visible = true;
//                disconnectButton.Visible = false;
//            }
//        }
//    }
//}