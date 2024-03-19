using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Client_PC01;
using Server;

namespace ClientServerTest
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

    [TestCleanup]
    public void Cleanup()
    {
        // Stop the server
        server.Stop();
    }

}
