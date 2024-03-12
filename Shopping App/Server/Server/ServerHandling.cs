using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Server
{
    public class ServerHandling
    {
        private TcpListener listener;
        private TcpClient client;
        private NetworkStream stream;
        public event Action<string> OnMessageReceived;
        public event Action<byte[]> OnImageReceived;

        private int port;

        // initializes server on a specific port
        public ServerHandling(int port)
        {
            this.port = port;
        }

        //starts server and begins listening for client connections
        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"Server started on port {port}.");

            listener.BeginAcceptTcpClient(new AsyncCallback(HandleClientConnection), listener);
        }

        //handles incoming client connections
        private void HandleClientConnection(IAsyncResult ar)
        {
            client = listener.EndAcceptTcpClient(ar);
            stream = client.GetStream();
            Console.WriteLine("Client connected.");

            BeginRead();
        }

        //begins asynchronous read operation on the network stream
        private void BeginRead()
        {
            var buffer = new byte[4096];
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), buffer);
        }

        //callback method for asynchronous read operation
        private void ReadCallback(IAsyncResult ar)
        {
            int bytesRead = stream.EndRead(ar);
            if (bytesRead > 0)
            {
                byte[] buffer = (byte[])ar.AsyncState;
                ProcessDataBuffer(buffer, bytesRead);
                BeginRead();            //continue reading from the stream
            }
            else
            {
                DisconnectClient();
            }
        }

        //processes received data from client
        private void ProcessDataBuffer(byte[] buffer, int bytesRead)
        {
            byte dataType = buffer[0];
            // Copy the next 4 bytes for the length, ensuring not to alter the original buffer
            byte[] lengthBytes = new byte[4];
            Array.Copy(buffer, 1, lengthBytes, 0, 4);

            // If your system uses little-endian but the data is big-endian, reverse the bytes
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(lengthBytes);
            }
            int dataLength = BitConverter.ToInt32(lengthBytes, 0);

            //ensure the data length is positive and there is enough data received
            if (dataLength > 0 && bytesRead >= (dataLength + 5))            //dataType (1 byte) + length (4 bytes) + data
            {
                if (dataType == 0x01)       //text message
                {
                    //ensure not to read beyond the buffer size
                    int textLength = Math.Min(dataLength, bytesRead - 5);
                    string message = Encoding.UTF8.GetString(buffer, 5, textLength);
                    Console.WriteLine($"Received text: {message}");
                    OnMessageReceived?.Invoke(message);
                }
                else if (dataType == 0x02)          //image
                {
                    byte[] imageData = new byte[dataLength];
                    Array.Copy(buffer, 5, imageData, 0, Math.Min(dataLength, bytesRead - 5));
                    Console.WriteLine("Received image data.");
                    OnImageReceived?.Invoke(imageData);
                }
            }
        }

        //sends message to the connected client
        public void SendMessageToClient(string message)
        {
            if (client != null && client.Connected)
            {
                NetworkStream clientStream = client.GetStream();
                if (clientStream.CanWrite)
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    // You might need to prepend the message with its length or a message type identifier,
                    // depending on your client-server protocol
                    clientStream.Write(messageBytes, 0, messageBytes.Length);
                }
            }
        }

        //disconnects the client
        private void DisconnectClient()
        {
            Console.WriteLine("Client disconnected.");
            stream.Close();
            client.Close();
        }

        //finally, this stops the server
        public void Stop()
        {
            listener.Stop();
            Console.WriteLine("Server stopped.");
        }
    }
}