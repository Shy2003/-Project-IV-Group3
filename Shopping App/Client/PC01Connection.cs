using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client_PC01
{
    //class to manage the connection to the server, sending and receiving messages
    internal class PC01Connection
    {
        private TcpClient client;       //client for TCP network services
        private NetworkStream stream;       //stream for reading and writing data
        private string serverIp;        //server IP address
        private int serverPort;     //server port number

        //constructor: initializes a new instance of the PC01Connection class with specified IP and port
        public PC01Connection(string ip, int port)
        {
            serverIp = ip;
            serverPort = port;
        }

       // test

        //attempts to connect to the server using provided IP and port
        public bool Connect()
        {
            try
            {
                client = new TcpClient(serverIp, serverPort);       //establishes a connection
                stream = client.GetStream();        //retrieves the network stream
                return true;        //connection successful
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");           //logs any exceptions
                return false;       //connection failed
            }
        }

        //sends a text message to the server and waits for a response
        public string SendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message);     //converts the message into bytes
                stream.Write(data, 0, data.Length);         //sends the message bytes to the server
                Console.WriteLine($"Sent: {message}");

                //awaits response from the server
                data = new byte[256];       //allocates buffer for response
                int bytes = stream.Read(data, 0, data.Length);      //reads response from the server
                string responseData = Encoding.ASCII.GetString(data, 0, bytes);         //converts response bytes back into a string
                Console.WriteLine($"Received: {responseData}");
                return responseData;            //returns the servers response
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");           //logs any exceptions
                return null;            //indicates an error occurred
            }
        }

        //sends an image file to the server
        public bool SendImage(string imagePath)
        {
            try
            {
                //read the file into a byte array
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                //define a message type byte array (0x02 for image) (0x01 is for text)
                byte[] messageType = new byte[] { 0x02 };

                //get the length of the imageBytes array as a byte array
                byte[] imageLength = BitConverter.GetBytes(imageBytes.Length);

                //ensure byte order matches between client and server
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(imageLength);         //reverse to big-endian if system architecture is little-endian, I am assuming we are using modern PC's
                }

                //concatenate messageType, imageLength, and imageBytes
                byte[] messageToSend = messageType
                                       .Concat(imageLength)
                                       .Concat(imageBytes)
                                       .ToArray();

                //send the concatenated byte array to the server
                stream.Write(messageToSend, 0, messageToSend.Length);
                Console.WriteLine($"Sent image: {imagePath}");

                //I am assuming we don't want a confirmation response from the server
                //byte[] data = new byte[256];
                //int bytes = stream.Read(data, 0, data.Length);
                //string responseData = Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine($"Received: {responseData}");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return false;       //indicates failure to send the image
            }
        }

        //receives a message from the server
        public string ReceiveMessage()
        {
            try
            {
                byte[] data = new byte[1024];           //buffer for incoming data
                int bytes = stream.Read(data, 0, data.Length);      //reads data from the stream
                string responseData = Encoding.ASCII.GetString(data, 0, bytes);     //converts bytes to string
                Console.WriteLine($"Received: {responseData}");

                return responseData;        //returns the received message
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in receiving message: {e.Message}");          //logs any exceptions
                return "Error in receiving message.";           //indicates an error occurred while receiving
            }

            //connection is not closed here, allowing for further messages to be received or sent
        }

        //property to check if the client is currently connected
        public bool IsConnected
        {
            get { return client != null && client.Connected; }          //returns true if client is connected
        }

        //closes the connection and the network stream
        public void Disconnect()
        {
            //defensive programming practice
            if (stream != null) stream.Close();         //closes the stream if it's not null
            if (client != null) client.Close();         //closes the client connection if it's not null
        }
    }
}