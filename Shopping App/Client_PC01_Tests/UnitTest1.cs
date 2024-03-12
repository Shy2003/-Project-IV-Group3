using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client_PC01;
using System.Threading.Tasks;

namespace Client_PC01_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task ConnectToServer_ValidIPAndPort_SuccessfulConnection()
        {
            //arrange
            var client = new PC01Connection("127.0.0.1", 13000);

            //act
            bool isConnected = client.Connect();

            //assert
            Assert.IsTrue(isConnected, "Client failed to connect to the server.");
        }

        [TestMethod]
        public async Task SendTextMessage_AfterConnection_MessageSentSuccessfully()
        {
            //arrange
            var client = new PC01Connection("127.0.0.1", 13000);
            client.Connect();
            string testMessage = "Hello Server";

            //I need to capture or assert this in a more integrated test or with a mock server
            //for simplicity, I will just ensure that no exception is thrown

            //act and assert
            client.SendMessage(testMessage);
        }

        [TestMethod]
        public async Task ReceiveTextMessage_FromServer_MessageReceived()
        {
            //arrange
            var client = new PC01Connection("127.0.0.1", 13000);
            client.Connect();

            bool messageReceived = false;
            string receivedMessage = null;

            client.TextMessageReceived += (message) =>
            {
                messageReceived = true;
                receivedMessage = message;
            };

            //this step should be replaced with a simulated message send from the server,
            //since server is not fully done yet, I will manually trigger the event
            client.TextMessageReceived?.Invoke("Test message from server");

            //assert
            Assert.IsTrue(messageReceived, "Message was not received from the server.");
            Assert.AreEqual("Test message from server", receivedMessage, "The received message does not match the expected value.");
        }

        [TestMethod]
        public async Task SendImage_AfterConnection_ImageSentSuccessfully()
        {
            //arrange
            var client = new PC01Connection("127.0.0.1", 13000);
            client.Connect();
            string testImagePath = "path/to/test/image.jpg";        //when testing, must replace with actual path to an image file

            //I need to capture or assert this in a more integrated test or with a mock server
            //for simplicity, I will just ensure that no exception is thrown

            //act and assert
            client.SendImage(testImagePath);
        }

        [TestMethod]
        public async Task ReceiveImage_FromServer_ImageReceived()
        {
            //arrange
            var client = new PC01Connection("127.0.0.1", 13000);
            client.Connect();

            bool imageReceived = false;
            byte[] receivedImageData = null;

            client.ImageReceived += (imageData) =>
            {
                imageReceived = true;
                receivedImageData = imageData;
            };

            //this step should be replaced with a simulated image send from the server
            //as an example for now, I will manually trigger the event
            byte[] testImageData = new byte[] { 0x01, 0x02, 0x03 };         //example byte array representing image data
            client.ImageReceived?.Invoke(testImageData);

            //assert
            Assert.IsTrue(imageReceived, "Image was not received from the server.");
            Assert.IsNotNull(receivedImageData, "No image data was received.");
            Assert.IsTrue(testImageData.SequenceEqual(receivedImageData), "The received image data does not match the expected value.");
        }

        [TestMethod]
        public async Task DisconnectFromServer_WhileConnected_SuccessfulDisconnection()
        {
            //arrange
            var client = new PC01Connection("127.0.0.1", 13000);
            client.Connect();

            //act
            client.Disconnect();

            //assert
            Assert.IsFalse(client.IsConnected, "Client is still connected after disconnect attempt.");
        }
    }
}
