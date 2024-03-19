using Client_PC01;
using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EthanTests
{
    [TestClass]
    public class ConnectionTests
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
            // Arrange
            var connection = new PC01Connection("127.0.0.1", 13000);

            // Act
            bool isConnected = connection.Connect();

            // Assert
            Assert.IsTrue(isConnected, "Failed to connect to the server.");
            Assert.IsTrue(connection.Connected, "Connection not marked as connected.");
        }

        [TestMethod]
        public void TestSendingTextMessage()
        {
            // Arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            string testMessage = "Hello, server!";
            bool messageReceived = false;
            server.TextMessageReceived += (message) => messageReceived = message == testMessage;

            // Act
            connection.SendTextMessage(testMessage);
            Thread.Sleep(500); // Wait for the message to be processed

            // Assert
            Assert.IsTrue(messageReceived, "Text message was not received by the server.");
        }

        [TestMethod]
        public void TestSendingImage()
        {
            // Arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            byte[] testImageBytes = File.ReadAllBytes("C:\\Users\\EthanNguyen\\Downloads\\pngtest.png");
            bool imageReceived = false;
            server.ImageReceived += (imageBytes) => imageReceived = imageBytes.SequenceEqual(testImageBytes);

            // Act
            connection.SendImage(testImageBytes);
            Thread.Sleep(500); // Wait for the image to be processed

            // Assert
            Assert.IsTrue(imageReceived, "Image was not received by the server.");
        }

        [TestMethod]
        public void TestDisconnection()
        {
            // Arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();

            // Act
            connection.Disconnect();

            // Assert
            Assert.IsFalse(connection.Connected, "Client is still marked as connected after disconnection.");
        }




        [TestCleanup]
        public void Cleanup()
        {
            // Stop the server
            server.Stop();
        }
    }


}