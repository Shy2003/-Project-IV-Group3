using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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

        var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
        try
        {
            while (true)
            {
                string message = reader.ReadLine();
                if (message == null)
                {
                    DisconnectClient();
                    break;
                }

                MessageReceived?.Invoke(message);
                Console.WriteLine("Client connected.");
            }
        }
        catch (IOException)
        {
            DisconnectClient();
        }
    }

    
    public void SendMessage(string message)
    {
        if (client.Connected)
        {
            var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true);
            // Write message size
            writer.Write(message.Length);
            // Write message
            writer.Write(message.ToCharArray());
            writer.Flush();
        }
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
