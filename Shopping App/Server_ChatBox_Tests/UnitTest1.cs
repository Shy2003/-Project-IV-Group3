using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;




namespace Server_ChatBox_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ServerHandling server;

        [TestInitialize]
        public void Initialize()
        {
            // Start the server
            server = new ServerHandling(13000);
        }


        [TestMethod]
        public void TestConnection()
        {
            //AcceptClient cannot be directly tested becuase the method is private, so I will simulate a mock client to test the connection
            // Arrange
            

            // Act
            var client = new TcpClient();
            client.Connect("127.0.0.1", 13000);
            Thread.Sleep(100); // Wait for connection establishment

            // Assert
            Assert.IsTrue(client.Connected, "Client should be connected.");

            // Cleanup
            client.Close();
            server.Stop();
        }


        [TestMethod]
        public void TestSendTextMessage()
        {
            // Arrange
            var client = new TcpClient();
            client.Connect("localhost", 13000);

            // Act
            server.SendTextMessage("Test message");

            // Assert
            // You can't directly test the message reception here, but you can check if no exceptions are thrown
            Assert.IsTrue(true, "Text message sent successfully.");
        }

        [TestMethod]
        public void TestSendImage()
        {
            // Arrange
            var client = new TcpClient();
            client.Connect("localhost", 13000);
            string testImagePath = "C:\\Users\\brian\\Pictures\\Camera Roll\\Result.png"; //File path to an image on my PC

            // Act
            server.SendImage(testImagePath);

            // Assert
            // You can't directly test the image reception here, but you can check if no exceptions are thrown
            Assert.IsTrue(true, "Image sent successfully.");
        }

        [TestMethod]
        public void TestDisconnectClient()
        {
            // Arrange
            var client = new TcpClient();
            client.Connect("localhost", 13000);

            // Act
            server.DisconnectClient();

            // Assert
            Assert.IsFalse(client.Connected, "Client should be disconnected.");
        }

        [TestMethod]
        public void TestStop()
        {
            // Arrange 
            //server object has already been instialized in Initialize(), so I will go ahead to Act and Assert

            // Act
            server.Stop();

            // Assert
            Assert.IsTrue(true, "Server stopped successfully.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Stop the server
            server.Stop();
        }
    }
}