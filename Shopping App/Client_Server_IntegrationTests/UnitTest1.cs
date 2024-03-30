using Client_PC01;
using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Net.Sockets;
using System.Text;

namespace Client_Server_IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        private ServerHandling server;
        private PC01Connection client;


        [TestInitialize]
        public void Initialize()
        {
            // Start the server
            server = new ServerHandling(13000);
            client = new PC01Connection("localhost", 13000);
        }

        [TestMethod]
        public void TestClientConnection()
        {
            // Arrange & Act
            var client = new PC01Connection("localhost", 13000);

            // Assert
            Assert.IsTrue(client.Connect());
            Assert.IsTrue(client.Connected);


            // Cleanup
            client.Disconnect();
            server.Stop();
        }


        [TestMethod]
        public void TestClientDisconnection()
        {
            // Arrange
            var client = new PC01Connection("localhost", 13000);
            bool disconnected = false;
            client.Disconnected += () => disconnected = true;

            // Act
            client.Disconnect();

            // Assert
            Task.Delay(5000).Wait(); // A delay to ensure the disconnection event is processed
            Assert.IsTrue(disconnected);
            Assert.IsFalse(client.Connected);
        }

        // Arrange
        [TestMethod]
        public void TestServerReceiveTextMessage()
        {
            var client = new PC01Connection("localhost", 13000);
            client.Connect();
            string expectedMessage = "Hello, Integration Testing!";
            string receivedMessage = null;
            bool messageReceived = false;
            server.TextMessageReceived += (message) => {
                receivedMessage = message;
                messageReceived = message == expectedMessage;
            };

            // Act
            client.SendTextMessage(expectedMessage);
            Thread.Sleep(500); // Wait for the message to be processed

            // Assert
            Assert.IsTrue(messageReceived, "Text message was not received by the server.");
            Assert.AreEqual(expectedMessage, receivedMessage, "Received message does not match the expected message.");
            client.Disconnect();
        }

        // Arrange
        [TestMethod]
        public void TestClientReceiveTextMessage()
        {
            var client = new PC01Connection("127.0.0.1", 13000);
            client.Connect();
            string expectedMessage = "Hello, Integration Testing!";
            string receivedMessage = null;
            bool messageReceived = false;
            client.TextMessageReceived += (message) => {
                receivedMessage = message;
                messageReceived = message == expectedMessage;
            };

            // Act
            server.SendTextMessage(expectedMessage);
            Thread.Sleep(500); // Wait for the message to be processed

            // Assert
            Assert.IsTrue(messageReceived, "Text message was not received by the client.");
            Assert.AreEqual(expectedMessage, receivedMessage, "Received message does not match the expected message.");
            client.Disconnect();
        }

        [TestMethod]
        public void TestServerReceiveImage()
        {
            var client = new PC01Connection("localhost", 13000);
            client.Connect();

            byte[] expectedImageBytes = File.ReadAllBytes("C:\\Users\\brian\\Pictures\\Camera Roll\\Result.png"); // Read image bytes from file
            byte[] receivedImageBytes = null;
            bool imageReceived = false;
            server.ImageReceived += (image) => {
                receivedImageBytes = image;
                imageReceived = CompareArrays(receivedImageBytes, expectedImageBytes);
            };

            client.SendImage(expectedImageBytes); // Send image bytes directly
            Thread.Sleep(500); // Wait for the image to be processed

            Assert.IsTrue(imageReceived, "Image was not received by the server.");
            CollectionAssert.AreEqual(expectedImageBytes, receivedImageBytes, "Received image bytes do not match the expected image bytes.");

            client.Disconnect();
        }


        [TestMethod]
        public void TestClientReceiveImage()
        {
            var client = new PC01Connection("127.0.0.1", 13000);
            client.Connect();

            byte[] expectedImageBytes = File.ReadAllBytes("C:\\Users\\brian\\Pictures\\Camera Roll\\Result.png");
            byte[] receivedImageBytes = null;
            bool imageReceived = false;
            client.ImageReceived += (image) => {
                receivedImageBytes = image;
                imageReceived = CompareArrays(receivedImageBytes, expectedImageBytes);
            };

            server.SendImage("C:\\Users\\brian\\Pictures\\Camera Roll\\Result.png");
            Thread.Sleep(500); // Wait for the image to be processed

            Assert.IsTrue(imageReceived, "Image was not received by the client.");
            CollectionAssert.AreEqual(expectedImageBytes, receivedImageBytes, "Received image bytes do not match the expected image bytes.");

            client.Disconnect();
        }

        // Helper method to compare byte arrays
        private bool CompareArrays(byte[] arr1, byte[] arr2)
        {
            if (arr1 == null || arr2 == null || arr1.Length != arr2.Length)
                return false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;
        }



        [TestCleanup]
        public void Cleanup()
        {
            // Disconnect the client and stop the server after each test
            client?.Disconnect();
            server.Stop();
        }




    }
}

