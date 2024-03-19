using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public class ServerHandling
{
    private TcpListener listener;
    private TcpClient client;
    private NetworkStream stream;

    public event Action<string> MessageReceived;

    public ServerHandling(int port)
    {
        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();

        new Thread(AcceptClient).Start();
    }

    private void AcceptClient()
    {
        client = listener.AcceptTcpClient();
        stream = client.GetStream();
        Console.WriteLine("Client connected.");

        var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
        try
        {
            while (true)
            {
                if (!client.Connected)
                {
                    DisconnectClient();
                    break;
                }
                string message = reader.ReadLine();
                if (message == null)
                {
                    DisconnectClient();
                    break;
                }

                MessageReceived?.Invoke(message);
            }
        }
        catch (IOException)
        {
            DisconnectClient();
        }
    }

    public void SendMessage(string message)
    {
        if (client != null && client.Connected)
        {
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
                        DisconnectClient();
                        break;
                    }

                    MessageReceived?.Invoke(message); // Update to the GUI listbox
                }
            }
        }
        catch (IOException)
        {
            DisconnectClient();
        }
    }

    public void OnTextMessageReceived(string message)
    {
        MessageReceived?.Invoke(message);
    }

    public void DisconnectClient()
    {
        stream?.Close();
        client?.Close();
    }

    public void Stop()
    {
        listener?.Stop();
    }
}
