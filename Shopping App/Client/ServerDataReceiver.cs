//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading.Tasks;

//namespace Client_PC01
//{
//    public class ServerDataReceiver
//    {
//        private TcpClient client;
//        private NetworkStream stream;
//        private Action<string> displayMessage;
//        private Action<byte[]> displayReceivedImage;

//        public ServerDataReceiver(TcpClient client, Action<string> displayMessage, Action<byte[]> displayReceivedImage)
//        {
//            this.client = client;
//            this.stream = client.GetStream();
//            this.displayMessage = displayMessage;
//            this.displayReceivedImage = displayReceivedImage;
//            BeginReceive();
//        }

//        private void BeginReceive()
//        {
//            var buffer = new byte[4096];
//            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReceiveCallback), buffer);
//        }

//        private void ReceiveCallback(IAsyncResult ar)
//        {
//            int bytesRead = stream.EndRead(ar);
//            if (bytesRead > 0)
//            {
//                byte[] buffer = (byte[])ar.AsyncState;
//                //the first byte indicates the type of data: 0x01 for text, 0x02 for image
//                byte dataType = buffer[0];

//                //extract the data length (it's the next 4 bytes after dataType, per our protocol)
//                int dataLength = BitConverter.ToInt32(buffer, 1);

//                if (dataType == 0x01)           //text message
//                {
//                    string message = Encoding.UTF8.GetString(buffer, 5, dataLength);
//                    displayMessage?.Invoke(message);
//                }
//                else if (dataType == 0x02)          //image
//                {
//                    byte[] imageData = new byte[dataLength];
//                    Array.Copy(buffer, 5, imageData, 0, dataLength);
//                    displayReceivedImage?.Invoke(imageData);
//                }

//                BeginReceive();         //continue receiving data
//            }
//            else
//            {
//                //handle disconnection or zero bytes read
//                Console.WriteLine("Server disconnected.");
//            }
//        }
//    }
//}
