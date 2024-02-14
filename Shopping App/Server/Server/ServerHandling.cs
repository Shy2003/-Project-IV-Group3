using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ServerHandling
{
    TcpListener server = null;

    public ServerHandling(string ip, int port)
    {
        IPAddress localAddr = IPAddress.Parse(ip);
        server = new TcpListener(localAddr, port);
    }

    public void Start()
    {
        server.Start();
        while (true)
        {
            Console.WriteLine("Waiting for a connection...");
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected!");

            Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
            t.Start(client);
        }
    }

    void HandleClient(object obj)
    {
       

        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();

        byte[] bytes = new byte[256];
        int i;
        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        {
            string data = Encoding.ASCII.GetString(bytes, 0, i);
            Console.WriteLine("Received: {0}", data);

            string response = "Hello From Server xD";

            byte[] msg = Encoding.ASCII.GetBytes(response);
            stream.Write(msg, 0, msg.Length);
            Console.WriteLine("Sent: {0}", response);
        }
        client.Close();
    }
}
