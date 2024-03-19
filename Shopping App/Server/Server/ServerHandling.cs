using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ServerHandling
{
    private TcpListener listener;
    private TcpClient client;
    private NetworkStream stream;
    private int port;
    private Thread acceptThread;
    private volatile bool isListening;

    // Event to notify about received messages
    public event Action<string> MessageReceived;

    public ServerHandling(int port)
    {
        this.port = port;
    }

    public void Start()
    {
        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        isListening = true;
        Console.WriteLine($"Server started on port {port}.");

        acceptThread = new Thread(() =>
        {
            try
            {
                while (isListening)
                {
                    client = listener.AcceptTcpClient();
                    if (!isListening) break;

                    stream = client.GetStream();
                    Console.WriteLine("Client connected.");

                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received from client: {message}");

                        // Notify subscribers about the received message
                        MessageReceived?.Invoke("Client: " + message);

                        // Optionally, you can send a response back to the client here
                    }
                }
            }
            catch (SocketException ex)
            {
                if (isListening)
                {
                    Console.WriteLine($"SocketException: {ex.Message}");
                }
            }
            finally
            {
                client?.Close();
                stream?.Close();
            }
        });

        acceptThread.Start();
    }

    public void Stop()
    {
        isListening = false;
        listener?.Stop();

        client?.Close();
        stream?.Close();
        acceptThread?.Join();
        Console.WriteLine("Server stopped.");
    }

    // Method to send a message to the connected client
    public void SendMessage(string message)
    {
        if (client != null && client.Connected && stream != null)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            stream.Write(messageBytes, 0, messageBytes.Length);
            stream.Flush();
        }
    }
}
