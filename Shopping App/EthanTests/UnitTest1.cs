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

        // test pushing
        // abcxyz

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
        public void INT003_TestSendingImage()
        {
            // Arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            byte[] testImageBytes = File.ReadAllBytes($"../../../../image_0.png");
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


        /// <summary>
        /// Ali tests
        /// </summary>



        [TestMethod]
        public void TestConnectionWithInvalidIP()
        {
            //arrange
            var connection = new PC01Connection("256.256.256.256", 13000);

            //act
            bool isConnected = connection.Connect();

            //assert
            Assert.IsFalse(isConnected, "Connection should fail with an invalid IP.");
        }

        [TestMethod]
        public void TestConnectionWithInvalidPort()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 999999);

            //act
            bool isConnected = connection.Connect();

            //assert
            Assert.IsFalse(isConnected, "Connection should fail with an invalid port.");
        }

        [TestMethod]
        public void TestSendingLargeTextMessage()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            string largeMessage = new string('a', 10000);           //large message
            bool messageReceived = false;
            server.TextMessageReceived += (message) => messageReceived = message == largeMessage;

            //act
            connection.SendTextMessage(largeMessage);
            Thread.Sleep(500);

            //assert
            Assert.IsTrue(messageReceived, "Large text message was not received by the server.");
        }

        [TestMethod]
        public void TestSendingEmptyTextMessage()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            string emptyMessage = "";
            bool messageReceived = false;
            server.TextMessageReceived += (message) => messageReceived = true;          //should not trigger

            //act
            connection.SendTextMessage(emptyMessage);
            Thread.Sleep(500);

            //assert
            Assert.IsFalse(messageReceived, "Empty text message should not be sent.");
        }

        [TestMethod]
        public void TestConnectionTimeout()
        {
            //arrange
            var connection = new PC01Connection("10.255.255.1", 13000);         //using an IP that is unreachable

            //act
            bool isConnected = connection.Connect();

            //assert
            Assert.IsFalse(isConnected, "Connection should timeout.");
        }

        [TestMethod]
        public void TestMultipleConnections()
        {
            //arrange
            var connection1 = new PC01Connection("127.0.0.1", 13000);
            var connection2 = new PC01Connection("127.0.0.1", 13000);

            //act
            bool firstConnection = connection1.Connect();
            bool secondConnection = connection2.Connect();

            //assert
            Assert.IsTrue(firstConnection && secondConnection, "Both connections should be successful.");
        }

        [TestMethod]
        public void TestDisconnectWithoutConnect()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);

            //act & assert
            Assert.ThrowsException<InvalidOperationException>(() => connection.Disconnect(), "Disconnecting without connecting first should throw an exception.");
        }

        [TestMethod]
        public void TestSendingTextAfterDisconnect()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            connection.Disconnect();
            string testMessage = "Should not send";
            bool messageSent = false;

            //trying to send a message after disconnect should ideally not occur
            //the server should not receive this message
            server.TextMessageReceived += (message) => messageSent = true;

            //act
            connection.SendTextMessage(testMessage);
            Thread.Sleep(500);          //wait for any possible message delivery

            //assert
            Assert.IsFalse(messageSent, "Message should not be sent after disconnection.");
        }

        [TestMethod]
        public void TestReconnectAfterDisconnect()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            connection.Disconnect();

            //act
            bool isConnected = connection.Connect();

            //assert
            Assert.IsTrue(isConnected, "Should be able to reconnect after disconnect.");
        }

        [TestMethod]
        public void TestConnectionWithWrongProtocol()
        {
            //arrange
            var connection = new PC01Connection("http://127.0.0.1", 13000); // Intentionally incorrect protocol

            //act
            bool isConnected = connection.Connect();

            //assert
            Assert.IsFalse(isConnected, "Connection with wrong protocol should fail.");
        }

        [TestMethod]
        public void TestSendLargeImage()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            byte[] largeImageBytes = new byte[10_000_000]; // 10 MB image
            bool imageReceived = false;
            server.ImageReceived += (imageBytes) => imageReceived = true;

            //act
            connection.SendImage(largeImageBytes);
            Thread.Sleep(1000); // Wait for the image to be processed

            //assert
            Assert.IsTrue(imageReceived, "Large image was not received by the server.");
        }

        [TestMethod]
        public void TestConnectionUnderHighLoad()
        {
            //arrange
            bool allConnectionsSuccessful = true;
            const int connectionCount = 100;

            //act
            Parallel.For(0, connectionCount, (i, state) =>
            {
                var connection = new PC01Connection("127.0.0.1", 13000);
                if (!connection.Connect())
                {
                    allConnectionsSuccessful = false;
                    state.Stop();
                }
            });

            //assert
            Assert.IsTrue(allConnectionsSuccessful, "Not all connections under high load were successful.");
        }

        [TestMethod]
        public void TestDisconnectionUnderHighLoad()
        {
            //arrange
            const int connectionCount = 100;
            var connections = new List<PC01Connection>();

            for (int i = 0; i < connectionCount; i++)
            {
                var connection = new PC01Connection("127.0.0.1", 13000);
                connection.Connect();
                connections.Add(connection);
            }

            //act
            connections.ForEach(connection => connection.Disconnect());

            //assert
            Assert.IsTrue(connections.All(connection => !connection.Connected), "Not all connections were successfully disconnected under high load.");
        }

        [TestMethod]
        public void TestInvalidImageFormat()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            byte[] invalidImageBytes = { 0xFF };            //invalid image data
            bool errorOccurred = false;
            server.ImageReceived += (imageBytes) => errorOccurred = true;       //should not trigger ideally

            //act
            connection.SendImage(invalidImageBytes);
            Thread.Sleep(500);

            //assert
            Assert.IsFalse(errorOccurred, "Server should not accept invalid image format.");
        }

        [TestMethod]
        public void TestSendingTextMessageConcurrently()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            int messageCount = 100;
            int receivedCount = 0;
            server.TextMessageReceived += (message) => Interlocked.Increment(ref receivedCount);

            //act
            Parallel.For(0, messageCount, (i) =>
            {
                connection.SendTextMessage($"Message {i}");
            });
            Thread.Sleep(1000);             //allow time for all messages to be processed

            //assert
            Assert.AreEqual(messageCount, receivedCount, "Not all text messages were received concurrently.");
        }

        [TestMethod]
        public void TestServerResponseDelay()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            string message = "Testing delay";
            bool messageReceived = false;
            server.TextMessageReceived += (receivedMessage) =>
            {
                if (receivedMessage == message)
                {
                    Thread.Sleep(2000);             //simulate server processing delay
                    messageReceived = true;
                }
            };

            //act
            var startTime = DateTime.Now;
            connection.SendTextMessage(message);
            Thread.Sleep(500);              //wait for the message to be sent
            var endTime = DateTime.Now;

            //assert
            Assert.IsTrue(messageReceived, "Message was not received.");
            Assert.IsTrue((endTime - startTime).TotalSeconds > 2, "Server did not simulate the delay correctly.");
        }

        [TestMethod]
        public void TestDisconnectionDuringDataTransfer()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            byte[] largeData = new byte[1024 * 1024 * 10];              //10 MB of data
            bool errorOccurred = false;
            server.ImageReceived += (data) => errorOccurred = true;             //should not complete

            //act
            Task.Run(() => connection.SendImage(largeData));
            Thread.Sleep(100);              //wait a bit for the data transfer to start
            connection.Disconnect();

            //assert
            Thread.Sleep(1000);             //allow time for any potential processing
            Assert.IsFalse(errorOccurred, "Disconnection during data transfer should cancel the transfer.");
        }

        [TestMethod]
        public void TestServerNotRunning()
        {
            //arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            //intentionally not starting the server to simulate server down scenario

            //act
            bool isConnected = connection.Connect();

            //assert
            Assert.IsFalse(isConnected, "Should fail to connect when the server is not running.");
        }

        [TestMethod]
        public void INT011_SendingMultipleMessages() {
            // arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            string testMessage1 = "Hello";
            string testMessage2 = "World";
            bool messageReceived = false;
            server.TextMessageReceived += (message) => messageReceived = message == testMessage1;
            server.TextMessageReceived += (message) => messageReceived = message == testMessage2;

            // act
            connection.SendTextMessage(testMessage1);
            connection.SendTextMessage(testMessage2);
            Thread.Sleep(500);

            // assert
            Assert.IsTrue(messageReceived, "Text messages were not properly received by server.");

        }

        [TestMethod]
        public void INT012_MultipleImagesConcurrent()
        {
            // Arrange
            var connection = new PC01Connection("127.0.0.1", 13000);
            connection.Connect();
            List<byte[]> imageList = new List<byte[]>();
            for (int i = 0; i < 10; i++)
            {
                byte[] testImageBytes = File.ReadAllBytes($"../../../../image_{i}.png");
                imageList.Add(testImageBytes);
            }
            int imagesSent = 0;
            server.ImageReceived += (imageBytes) => Interlocked.Increment(ref imagesSent);

            // Act
            Parallel.ForEach(imageList, (imageBytes) =>
            {
                connection.SendImage(imageBytes);
            });
            Thread.Sleep(1000); // Wait for all images to be processed

            // Assert
            Assert.AreEqual(imageList.Count, imagesSent, "Not all images were sent and received.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Stop the server
            server.Stop();
        }
    }


}