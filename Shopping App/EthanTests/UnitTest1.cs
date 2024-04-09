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

        [TestCleanup]
        public void Cleanup()
        {
            // Stop the server
            server.Stop();
        }
    }

    namespace EthanTests
    {
        [TestClass]
        public class IntegrationTests
        {
            private ServerHandling server;

            [TestInitialize]
            public void Initialize()
            {
                server = new ServerHandling(13000);
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

            [TestCleanup]
            public void Cleanup()
            {
                server.Stop();
            }
        }
    }

    namespace EthanTests
    {
        public class EdgeCaseTests
        {
            private ServerHandling server;

            [TestInitialize]
            public void Initialize()
            {
                server = new ServerHandling(13000);
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

            [TestCleanup]
            public void Cleanup()
            {
                server.Stop();
            }

        }
    } 
}
