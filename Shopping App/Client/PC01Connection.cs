using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_PC01
{
    public class PC01Connection
    {
        private TcpClient client;
        private NetworkStream stream;
        private readonly string ip;
        private readonly int port;

        public event Action<string> TextMessageReceived;
        public event Action<byte[]> ImageReceived;
        public event Action Disconnected;

        public bool Connected => client != null && client.Connected;

        public PC01Connection(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            client = new TcpClient();
            Task.Run(() => Connect());
        }

        public bool Connect()
        {
            if (Connected)
            {
                return true; // Already connected
            }

            try
            {
                client.Connect(ip, port);
                stream = client.GetStream();
                Task.Run(() => ListenForMessages());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to the server: {ex.Message}");
                return false;
            }
        }

        public void SendTextMessage(string message)
        {
            if (Connected)
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                byte[] typeBytes = Encoding.UTF8.GetBytes("TEXT"); // 4-byte type header
                byte[] lengthBytes = BitConverter.GetBytes(messageBytes.Length);

                stream.Write(typeBytes, 0, typeBytes.Length);
                stream.Write(lengthBytes, 0, lengthBytes.Length);
                stream.Write(messageBytes, 0, messageBytes.Length);
            }
            else
            {
                // Handle the case when not connected
            }
        }

        public void SendImage(byte[] imageBytes)
        {
            if (Connected)
            {
                byte[] typeBytes = Encoding.UTF8.GetBytes("IMG_"); // 4-byte type header
                byte[] lengthBytes = BitConverter.GetBytes(imageBytes.Length);

                stream.Write(typeBytes, 0, typeBytes.Length);
                stream.Write(lengthBytes, 0, lengthBytes.Length);
                stream.Write(imageBytes, 0, imageBytes.Length);
            }
            else
            {
                // Handle the case when not connected
            }
        }

        private void ListenForMessages()
        {
            try
            {
                while (client.Connected)
                {
                    string dataType = ReadDataType();
                    int contentLength = ReadContentLength();

                    if (dataType == "IMG_")
                    {
                        byte[] imageBytes = ReadContentBytes(contentLength);
                        ImageReceived?.Invoke(imageBytes);
                    }
                    else if (dataType == "TEXT")
                    {
                        string textMessage = ReadTextMessage(contentLength);
                        TextMessageReceived?.Invoke(textMessage);
                    }
                }
            }
            catch (IOException)
            {
                Disconnect();
            }
        }

        private string ReadDataType()
        {
            var typeBuffer = new byte[4];
            int bytesRead = stream.Read(typeBuffer, 0, 4);
            if (bytesRead == 0) throw new IOException("Connection closed");

            return Encoding.UTF8.GetString(typeBuffer).Trim();
        }

        private int ReadContentLength()
        {
            var lengthBuffer = new byte[4];
            int bytesRead = stream.Read(lengthBuffer, 0, 4);
            if (bytesRead == 0) throw new IOException("Connection closed");

            return BitConverter.ToInt32(lengthBuffer, 0);
        }

        private string ReadTextMessage(int contentLength)
        {
            var messageBuffer = new byte[contentLength];
            int bytesRead = stream.Read(messageBuffer, 0, messageBuffer.Length);
            if (bytesRead == 0) throw new IOException("Connection closed");

            return Encoding.UTF8.GetString(messageBuffer);
        }

        private byte[] ReadContentBytes(int contentLength)
        {
            var contentBuffer = new byte[contentLength];
            int bytesRead = stream.Read(contentBuffer, 0, contentBuffer.Length);
            if (bytesRead == 0) throw new IOException("Connection closed");

            return contentBuffer;
        }

        public void Disconnect()
        {
            stream?.Close();
            client?.Close();
            Disconnected?.Invoke();
        }
    }
}
