using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerChatBox : Form
    {
        private TcpListener tcpListener;
        private List<TcpClient> connectedClients = new List<TcpClient>();
        private Thread listenThread;

        public ServerChatBox()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, 8080);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                connectedClients.Add(client);

                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }


        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] messageBuffer = new byte[4096];
            StringBuilder completeMessage = new StringBuilder();
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = clientStream.Read(messageBuffer, 0, messageBuffer.Length);
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., client disconnected)
                    Console.WriteLine("Error reading message: " + ex.Message);
                    break;
                }

                if (bytesRead == 0)
                {
                    // Client disconnected
                    break;
                }

                string message = Encoding.ASCII.GetString(messageBuffer, 0, bytesRead);
                completeMessage.Append(message);

                // Check for end of message
                if (completeMessage.ToString().Contains("<EOF>"))
                {
                    string finalMessage = completeMessage.ToString().Replace("<EOF>", "");

                    // Display message in the ListBox
                    AddMessageToListBox(finalMessage);

                    completeMessage.Clear();
                }
            }

            // Remove client from the list of connected clients
            connectedClients.Remove(tcpClient);
        }

        private void AddMessageToListBox(string message)
        {
            if (MessageDisplayListBox.InvokeRequired)
            {
                MessageDisplayListBox.Invoke(new MethodInvoker(delegate
                {
                    MessageDisplayListBox.Items.Add(message);
                }));
            }
            else
            {
                MessageDisplayListBox.Items.Add(message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This is the event handler for the "Send" button
            string message = BroadcastMessageTextBox.Text;

            // Broadcast the message to all connected clients
            byte[] messageBytes = Encoding.ASCII.GetBytes(message + "<EOF>");
            foreach (TcpClient client in connectedClients)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(messageBytes, 0, messageBytes.Length);
            }

            // Clear the broadcast message TextBox
            BroadcastMessageTextBox.Clear();
        }



        private void ServerChatBox_Load(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MessageDisplayListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BroadcastMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ServerRunningLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
