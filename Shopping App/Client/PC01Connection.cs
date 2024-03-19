using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client_PC01
{
    public class PC01Connection
    {
        //TcpClient used for TCP network services
        private TcpClient client;
        //NetworkStream for reading and writing data
        private NetworkStream stream;
        //IP address of the server
        private string serverIp;
        //port number for the server connection
        private int serverPort;
        //event triggered when a text message is received from the server
        public event Action<string> TextMessageReceived;
        //event triggered when an image data byte array is received from the server
        public event Action<byte[]> ImageReceived;

        //constructor initializing the connection with the server's IP address and port
        //automatically attempts to connect upon instantiation
        public PC01Connection(string ip, int port)
        {
            serverIp = ip;
            serverPort = port;
            Connect();
        }

        //attempts to establish a connection to the server. returns true if successful
        public bool Connect()
        {
            try
            {
                //initializes the TCP connection to the specified server IP and port
                client = new TcpClient(serverIp, serverPort);
                stream = client.GetStream();
                //begins listening for incoming messages as soon as the connection is established
                BeginReceiveMessages();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Connection exception: {e.Message}");
                return false;
            }
        }

        //closes the connection and releases the resources
        public void Disconnect()
        {
            stream?.Close();
            client?.Close();
        }

        //checks if the client is currently connected to the server
        public bool IsConnected => client != null && client.Connected;

        //sends a text message to the server using the established TCP connection
        public void SendMessage(string message)
        {
            if (!IsConnected) throw new InvalidOperationException("Not connected to a server.");

            var messageBytes = Encoding.UTF8.GetBytes(message);
            SendData(0x01, messageBytes); // 0x01 will denote a text message
        }

        //sends an image file to the server by reading the file content and sending it as byte array
        public void SendImage(string imagePath)
        {
            var imageBytes = File.ReadAllBytes(imagePath);
            SendData(0x02, imageBytes);
        }

        //generic method for sending data with a specified data type to the server
        private void SendData(byte dataType, byte[] data)
        {
            //prepares the data packet with the data type, data length, and data content
            var dataLength = BitConverter.GetBytes(data.Length);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(dataLength);
            }

            var packet = new byte[1 + 4 + data.Length];
            packet[0] = dataType;                   //indicates the type of data being sent (text or image)
            Array.Copy(dataLength, 0, packet, 1, 4);            //includes the length of the data
            Array.Copy(data, 0, packet, 5, data.Length);        //includes the actual data
            stream.Write(packet, 0, packet.Length);
        }

        //begins the asynchronous operation to listen for incoming messages from the server
        private void BeginReceiveMessages()
        {
            var buffer = new byte[4096];        //buffer for the incoming data
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), buffer);
        }

        //callback function for asynchronous read operation. processes the received data
        private void ReadCallback(IAsyncResult ar)
        {
            int bytesRead = stream.EndRead(ar);
            if (bytesRead > 0)
            {
                byte[] buffer = (byte[])ar.AsyncState;
                ProcessReceivedData(buffer.Take(bytesRead).ToArray());
                BeginReceiveMessages();     //continues listening for more messages
            }
            else
            {
                Console.WriteLine("No data read, client might have disconnected.");
                Disconnect();
            }
        }

        //processes the data received from the server, triggering the appropriate events
        private void ProcessReceivedData(byte[] data)
        {
            if (data.Length < 5) return;            //minimum length check (1 byte for dataType + 4 bytes for length) to ensure data integrity

            byte dataType = data[0];            //the first byte indicates the type of data (text or image)
            int dataLength = BitConverter.ToInt32(data, 1);             //the next 4 bytes represent the data length
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data, 1, 4);          //adjusts for endianess
                dataLength = BitConverter.ToInt32(data, 1);
            }

            //ensure data length is valid and does not exceed buffer bounds
            if (dataLength <= 0 || dataLength > data.Length - 5) return;

            byte[] messageData = data.Skip(5).Take(dataLength).ToArray();       //extracts the actual data

            //triggers the corresponding event based on the data type
            if (dataType == 0x01)           //text message
            {
                var message = Encoding.UTF8.GetString(messageData);
                TextMessageReceived?.Invoke(message);
            }
            else if (dataType == 0x02)          //image data
            {
                ImageReceived?.Invoke(messageData);
            }
        }
    }
}