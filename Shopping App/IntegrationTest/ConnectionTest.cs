using Client_PC01;
using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EthanTests.Connection
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
}