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
        private readonly string ip; //
        private readonly int port;


        // readonly keyword in C# is used to declare a field that can only be assigned a value once, either at the time of declaration or in the constructor of the class.
        public event Action Disconnected;
        public event Action<string> TextMessageReceived;

        public bool Connected => client != null && client.Connected;


        public PC01Connection(string ip, int port)
        {
            client = new TcpClient(ip, port);
            stream = client.GetStream();

            // Start listening to the server
            Task.Run(() => ListenForMessages());
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

                // Start listening to the server
                Task.Run(() => ListenForMessages());

                Console.WriteLine("Connected to server.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to the server: {ex.Message}"); // Log error message
                return false;
            }
        }


        public void SendMessage(string message)
        {
            if (Connected)
            {
                //using (var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true))
                //{
                //    // Write message size
                //    writer.Write(message.Length);
                //    // Write message
                //    writer.Write(message.ToCharArray());
                //    writer.Flush();
                //}
                var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true);
                writer.WriteLine(message); // WriteLine automatically adds a newline character
                writer.Flush();
            }
        }

        public void ListenForMessages()
        {
            try
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true))
                {
                    while (client.Connected)
                    {
                        string message = reader.ReadLine();
                        if (message == null)
                        {
                            Disconnect();
                            break;
                        }

                        TextMessageReceived?.Invoke(message); // Update to the GUI listbox by raising the event
                    }
                }
            }
            catch (IOException)
            {
                Disconnect();
            }
        }


        public void OnTextMessageReceived(string message)
        {
            TextMessageReceived?.Invoke(message);
        }

        public void Disconnect()
        {
            stream?.Close();
            client?.Close();
            Disconnected?.Invoke();

            MessageBox.Show("Disconnected from server.");

        }
    }
}
