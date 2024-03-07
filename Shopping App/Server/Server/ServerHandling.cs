using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Server
{
    public class ServerHandling
    {
        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private int port;

        public ServerHandling(int port)
        {
            this.port = port;
            this.server = new TcpListener(IPAddress.Any, port);
        }

        public bool Connect()
        {
            try
            {
                client = server.AcceptTcpClient();
                stream = client.GetStream();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return false;
            }
        }

        public string ReceiveMessage()
        {
            try
            {
                byte[] data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                string receivedMessage = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine($"Received: {receivedMessage}");
                return receivedMessage;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public void Disconnect()
        {
            stream.Close();
            client.Close();
        }

        public void Start()
        {
            try
            {
                server.Start();
                Console.WriteLine("Server is listening on port " + port);

                // Connect with client
                Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void Stop()
        {
            server.Stop();
        }


        public void HandleClient(TcpClient client, ListBox listBox)
        {
            NetworkStream stream = client.GetStream();

            byte[] data = new byte[256];
            string receivedMessage = string.Empty;

            while (true)
            {
                try
                {
                    // Receive message from client
                    int bytes = stream.Read(data, 0, data.Length);
                    receivedMessage = Encoding.ASCII.GetString(data, 0, bytes);

                    // Update the list box with the received message
                    listBox.Invoke(new Action(() =>
                    {
                        listBox.Items.Add(receivedMessage);
                    }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    break;
                }
            }

            // Close the connection
            client.Close();
        }

        public TcpClient CreateTcpClientFromSelectedItem(string selectedItem)
        {
            // Parse the selected item to extract connection information
            // For example, parse IP address and port number from the selected item
            string[] parts = selectedItem.Split(':');
            string ipAddress = parts[0];
            int port = int.Parse(parts[1]);

            try
            {
                // Create and return a TcpClient object based on the connection information
                return new TcpClient(ipAddress, port);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating TcpClient: " + ex.Message);
                return null;
            }
        }

    }




}