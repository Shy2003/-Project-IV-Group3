using Client_PC01;
using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
namespace IntegrationTest
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