using Client_PC01;
using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
namespace EdgeCases
{
    [TestClass]
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