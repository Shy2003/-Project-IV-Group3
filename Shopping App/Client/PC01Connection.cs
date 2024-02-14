using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_PC01
{
    internal class PC01Connection
    {
        private TcpClient client;
        private NetworkStream stream;
        private string serverIp;
        private int serverPort;

        public PC01Connection(string ip, int port)
        {
            serverIp = ip;
            serverPort = port;
        }

        public bool Connect()
        {
            try
            {
                client = new TcpClient(serverIp, serverPort);
                stream = client.GetStream();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return false;
            }
        }


        public string SendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {message}");

                // Receive response
                data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                string responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine($"Received: {responseData}");
                return responseData;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public void Disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}