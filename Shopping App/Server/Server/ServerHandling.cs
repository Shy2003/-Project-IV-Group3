using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

public class ServerHandling
{
    private TcpListener listener;
    private TcpClient client;
    private NetworkStream stream;

    public event Action<string> TextMessageReceived;
    public event Action<byte[]> ImageReceived;

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
            DisconnectClient();
        }
    }

    public void SendTextMessage(string message)
    {
        if (client.Connected)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] typeBytes = Encoding.UTF8.GetBytes("TEXT"); // 4-byte type header
            byte[] lengthBytes = BitConverter.GetBytes(messageBytes.Length);

            stream.Write(typeBytes, 0, typeBytes.Length);
            stream.Write(lengthBytes, 0, lengthBytes.Length);
            stream.Write(messageBytes, 0, messageBytes.Length);
        }
    }

    public void SendImage(string imagePath)
    {
        if (client.Connected)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            byte[] typeBytes = Encoding.UTF8.GetBytes("IMG_"); // 4-byte type header
            byte[] lengthBytes = BitConverter.GetBytes(imageBytes.Length);

            stream.Write(typeBytes, 0, typeBytes.Length);
            stream.Write(lengthBytes, 0, lengthBytes.Length);
            stream.Write(imageBytes, 0, imageBytes.Length);
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
