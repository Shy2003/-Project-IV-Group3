using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using System;
using FlaUI.Core.Conditions;
using FlaUI.Core.Tools;
using FlaUI.Core.Definitions;
using System.Linq;
using FlaUI.Core.Input;

namespace EthanTestUI
{
    [TestClass]
    public class UITests
    {
        private const string ApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Client\bin\Debug\net7.0-windows\Client_PC01.exe";

        [TestMethod]
        public void TestChatButtonOpensChatBox()
        {
            using (var app = Application.Launch(ApplicationPath))
            {
                using (var automation = new UIA3Automation())
                {
                    var mainWindow = app.GetMainWindow(automation);
                    var chatButton = mainWindow.FindFirstDescendant(cf => cf.ByText("ChatButton"));

                    chatButton?.AsButton().Click();

                    Thread.Sleep(5000); // Wait for the ChatBox to open
                    var chatBoxWindow = automation.GetDesktop().FindFirstDescendant(cf => cf.ByText("ChatBox"));
                    Assert.IsNotNull(chatBoxWindow, "ChatBox form was not opened.");
                }
            }
        }
    }

    [TestClass]
    public class ChatApplicationTests
    {
        private Application _serverApp;
        private Application _clientApp;
        private UIA3Automation _automation;
        private Window _serverMainWindow;
        private Window _clientMainWindow;

        private const string ServerApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Server\Server\bin\Debug\net7.0-windows\Server.exe";
        private const string ClientApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Client\bin\Debug\net7.0-windows\Client_PC01.exe";

        [TestInitialize]
        public void Initialize()
        {
            _automation = new UIA3Automation();
            _serverApp = Application.Launch(ServerApplicationPath);
            _clientApp = Application.Launch(ClientApplicationPath);
            _serverMainWindow = _serverApp.GetMainWindow(_automation);
            _clientMainWindow = _clientApp.GetMainWindow(_automation);
        }

        [TestMethod]
        public void TestServerStartAndClientConnect()
        {
            Task.Run(() =>
            {
                // Start the server in a separate thread
                _serverApp = Application.Launch(ServerApplicationPath);
                _serverMainWindow = _serverApp.GetMainWindow(_automation);
                var startServerButton = _serverMainWindow.FindFirstDescendant(cf => cf.ByText("StartServer")).AsButton();
                startServerButton.Click();
                HandleMessageBox("Server started");
            });

            Task.Run(() =>
            {
                // Connect the client in a separate thread
                _clientApp = Application.Launch(ClientApplicationPath);
                _clientMainWindow = _clientApp.GetMainWindow(_automation);
                var connectServerButton = _clientMainWindow.FindFirstDescendant(cf => cf.ByText("ConnectServer")).AsButton();
                connectServerButton.Click();
                HandleMessageBox("Connected to server");
            });

            // Add a delay to ensure the server and client have started and connected
            Thread.Sleep(5000);
        }

        private void HandleMessageBox(string expectedMessage)
        {
            var messageBox = Retry.WhileNull(() =>
                _automation.GetDesktop().FindFirstChild(cf => cf.ByClassName("#32770")),
                timeout: TimeSpan.FromSeconds(5)).Result;
            Assert.IsNotNull(messageBox, "Message box did not appear.");

            var messageLabel = messageBox.FindFirstChild(cf => cf.ByControlType(ControlType.Text)).AsLabel();
            Assert.IsTrue(messageLabel.Text.Contains(expectedMessage), $"Expected message '{expectedMessage}' was not found.");

            var okButtonCondition = new AndCondition(
                _automation.ConditionFactory.ByControlType(ControlType.Button),
                _automation.ConditionFactory.ByName("OK")
            );
            var okButton = messageBox.FindFirstChild(okButtonCondition).AsButton();
            okButton?.Invoke();
        }

        [TestMethod]
        public void TestOpenChatFunctionalityClient()
        {
            // Wait for the Open Chat button to become available
            var openChatButton = Retry.WhileNull(() =>
                _clientMainWindow.FindFirstDescendant(cf => cf.ByText("OpenChat")).AsButton(),
                timeout: TimeSpan.FromSeconds(5)).Result;
            Assert.IsNotNull(openChatButton, "Open Chat button not found.");
            Assert.IsTrue(openChatButton.IsEnabled, "Open Chat button should be enabled.");

            // Simulate a mouse click on the Open Chat button
            openChatButton.Focus(); // Bring the button into focus
            Mouse.Click(openChatButton.GetClickablePoint(), MouseButton.Left); // Simulate a left mouse click on the button

            // Wait for the chat list box to become available and check that it is visible
            var lstChat = Retry.WhileNull(() =>
                _clientMainWindow.FindFirstDescendant(cf => cf.ByAutomationId("lstChat")).AsListBox(),
                timeout: TimeSpan.FromSeconds(5)).Result;
            Assert.IsNotNull(lstChat, "Chat list control not found.");
            Assert.IsFalse(lstChat.Properties.IsOffscreen.ValueOrDefault, "Chat list should be visible.");

            var txtMessage = _clientMainWindow.FindFirstDescendant(cf => cf.ByAutomationId("txtMessage")).AsTextBox();
            Assert.IsNotNull(txtMessage, "Message text box control not found.");
            Assert.IsTrue(txtMessage.IsEnabled, "Message text box should be visible.");

            // Wait for the Send Message button to become available and check that it is enabled
            var btnSendMessagea = Retry.WhileNull(() =>
                _clientMainWindow.FindFirstDescendant(cf => cf.ByName("btnSend")).AsButton(), // Use the button's name
                timeout: TimeSpan.FromSeconds(5)).Result;
            Assert.IsNotNull(btnSendMessagea, "Send message button control not found.");
            Assert.IsTrue(btnSendMessagea.IsEnabled, "Send message button should be visible.");

        }


        [TestMethod]
        public void TestOpenChatFunctionalityServer()
        {
            // Wait for the Open Chat button to become available on the server side
            var openChatButtonServer = Retry.WhileNull(() =>
                _serverMainWindow.FindFirstDescendant(cf => cf.ByText("OpenChat")).AsButton(),
                timeout: TimeSpan.FromSeconds(5)).Result;
            Assert.IsNotNull(openChatButtonServer, "Open Chat button on server not found.");
            Assert.IsTrue(openChatButtonServer.IsEnabled, "Open Chat button on server should be enabled.");

            // Simulate a mouse click on the Open Chat button on the server side
            openChatButtonServer.Focus(); // Bring the button into focus
            Mouse.Click(openChatButtonServer.GetClickablePoint(), MouseButton.Left); // Simulate a left mouse click on the button

            // Wait for the chat list box to become available on the server side and check that it is visible
            var lstChatServer = Retry.WhileNull(() =>
                _serverMainWindow.FindFirstDescendant(cf => cf.ByAutomationId("lstChat")).AsListBox(),
                timeout: TimeSpan.FromSeconds(5)).Result;
            Assert.IsNotNull(lstChatServer, "Chat list control on server not found.");
            Assert.IsFalse(lstChatServer.Properties.IsOffscreen.ValueOrDefault, "Chat list on server should be visible.");

          
        }





        [TestCleanup]
        public void Cleanup()
        {
            _serverApp?.Close();
            _clientApp?.Close();
            _automation?.Dispose();
        }
    }


    


































    //[TestClass]
    //public class ChatApplicationTests
    //{
    //    private Application _serverApp;
    //    private Application _clientApp;
    //    public UIA3Automation _automation;
    //    private Window _serverMainWindow;
    //    private Window _clientMainWindow;

    //    private const string ServerApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Server\Server\bin\Debug\net7.0-windows\Server.exe";
    //    private const string ClientApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Client\bin\Debug\net7.0-windows\Client_PC01.exe";

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _automation = new UIA3Automation();
    //        _serverApp = Application.Launch(ServerApplicationPath);
    //        _clientApp = Application.Launch(ClientApplicationPath);
    //        _serverMainWindow = _serverApp.GetMainWindow(_automation);
    //        _clientMainWindow = _clientApp.GetMainWindow(_automation);
    //    }

    //    [TestMethod]
    //    public void TestChatFunctionality()
    //    {
    //        Task.Run(() =>
    //        {
    //            // Start the server in a separate thread
    //            _serverApp = Application.Launch(ServerApplicationPath);
    //            _serverMainWindow = _serverApp.GetMainWindow(_automation);
    //            var startServerButton = _serverMainWindow.FindFirstDescendant(cf => cf.ByText("StartServer")).AsButton();
    //            startServerButton.Click();
    //            HandleMessageBox("Server started");
    //        });

    //        Task.Run(() =>
    //        {
    //            // Connect the client in a separate thread
    //            _clientApp = Application.Launch(ClientApplicationPath);
    //            _clientMainWindow = _clientApp.GetMainWindow(_automation);
    //            var connectServerButton = _clientMainWindow.FindFirstDescendant(cf => cf.ByText("ConnectServer")).AsButton();
    //            connectServerButton.Click();
    //            HandleMessageBox("Connected to server");
    //        });

    //        // Add a delay to ensure the server and client have started and connected
    //        Thread.Sleep(5000);

    //        // Open the chat on the client side
    //        var openChatButtonClient = _clientMainWindow.FindFirstDescendant(cf => cf.ByText("OpenChat")).AsButton();
    //        openChatButtonClient.Click();
    //        HandleClearHistoryMessageBox();

    //        // Open the chat on the server side
    //        var openChatButtonServer = _serverMainWindow.FindFirstDescendant(cf => cf.ByText("Openchat")).AsButton();
    //        openChatButtonServer.Click();
    //        HandleClearHistoryMessageBox();

    //        // Type and send a message on the client side
    //        var chatBoxClient = _clientMainWindow.ModalWindows.FirstOrDefault(w => w.Title == "ChatBox");
    //        var messageTextBoxClient = chatBoxClient.FindFirstDescendant(cf => cf.ByAutomationId("txtMessage")).AsTextBox();
    //        var sendMessageButtonClient = chatBoxClient.FindFirstDescendant(cf => cf.ByAutomationId("btnSend")).AsButton();
    //        messageTextBoxClient.Enter("Hello from Client");
    //        sendMessageButtonClient.Click();

    //        // Type and send a message on the server side
    //        var chatBoxServer = _serverMainWindow.ModalWindows.FirstOrDefault(w => w.Title == "ServerChatBox");
    //        var messageTextBoxServer = chatBoxServer.FindFirstDescendant(cf => cf.ByAutomationId("txtMessage")).AsTextBox();
    //        var sendMessageButtonServer = chatBoxServer.FindFirstDescendant(cf => cf.ByAutomationId("btnSend")).AsButton();
    //        messageTextBoxServer.Enter("Hello from Server");
    //        sendMessageButtonServer.Click();

    //        // Verify the message was received on the client side
    //        var messageListClient = chatBoxClient.FindFirstDescendant(cf => cf.ByAutomationId("lstChat")).AsListBox();
    //        var lastMessageClient = messageListClient.Items.LastOrDefault();
    //        Assert.AreEqual("Server: Hello from Server", lastMessageClient?.Text, "The client should receive the message from the server.");

    //        // Verify the message was received on the server side
    //        var messageListServer = chatBoxServer.FindFirstDescendant(cf => cf.ByAutomationId("lstChat")).AsListBox();
    //        var lastMessageServer = messageListServer.Items.LastOrDefault();
    //        Assert.AreEqual("Client: Hello from Client", lastMessageServer?.Text, "The server should receive the message from the client.");
    //    }

    //    private void HandleClearHistoryMessageBox()
    //    {
    //        var clearHistoryMessageBox = Retry.WhileNull(() =>
    //            _automation.GetDesktop().FindFirstChild(cf => cf.ByText("Clear History")),
    //            timeout: TimeSpan.FromSeconds(5)).Result;

    //        if (clearHistoryMessageBox != null)
    //        {
    //            var noButton = clearHistoryMessageBox.FindFirstChild(cf => cf.ByControlType(ControlType.Button).And(cf.ByName("No"))).AsButton();
    //            noButton?.Invoke();
    //        }
    //    }


    //    private void HandleMessageBox(string expectedMessage)
    //    {
    //        var messageBox = Retry.WhileNull(() =>
    //            _automation.GetDesktop().FindFirstChild(cf => cf.ByClassName("#32770")),
    //            timeout: TimeSpan.FromSeconds(5)).Result;
    //        Assert.IsNotNull(messageBox, "Message box did not appear.");

    //        var messageLabel = messageBox.FindFirstChild(cf => cf.ByControlType(ControlType.Text)).AsLabel();
    //        Assert.IsTrue(messageLabel.Text.Contains(expectedMessage), $"Expected message '{expectedMessage}' was not found.");

    //        var okButtonCondition = new AndCondition(
    //            _automation.ConditionFactory.ByControlType(ControlType.Button),
    //            _automation.ConditionFactory.ByName("OK")
    //        );
    //        var okButton = messageBox.FindFirstChild(okButtonCondition).AsButton();
    //        okButton?.Invoke();
    //    }

    //    [TestCleanup]
    //    public void Cleanup()
    //    {
    //        _serverApp?.Close();
    //        _clientApp?.Close();
    //        _automation?.Dispose();
    //    }
    //}


    //[TestClass]
    //public class ServerChatboxTests
    //{
    //    private const string ServerApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Server\Server\bin\Debug\net7.0-windows\Server.exe";

    //    [TestMethod]
    //    public void StartServer_ShouldDisplayServerStartedMessage()
    //    {
    //        using (var serverApp = Application.Launch(ServerApplicationPath))
    //        {
    //            using (var serverAutomation = new UIA3Automation())
    //            {
    //                var serverWindow = serverApp.GetMainWindow(serverAutomation);
    //                var startServerButton = serverWindow.FindFirstDescendant(cf => cf.ByText("StartServer")).AsButton();

    //                Assert.IsNotNull(startServerButton, "Start Server button not found on the window.");

    //               startServerButton.Click();

    //                // Wait for the message box to appear using FlaUI's Retry pattern
    //                var messageBox = Retry.WhileNull(() =>
    //                {
    //                    // Attempt to find the message box as a new window
    //                    return serverAutomation.GetDesktop().FindAllChildren().FirstOrDefault(win =>
    //                        win.ClassName == "#32770" && !win.IsOffscreen);
    //                }, timeout: TimeSpan.FromSeconds(5), throwOnTimeout: false).Result;

    //                Assert.IsNotNull(messageBox, "MessageBox did not appear after clicking Start Server.");

    //                // Check if the message box contains the expected text
    //                var messageBoxText = messageBox.FindFirstChild(cf => cf.ByControlType(ControlType.Text)).AsLabel();
    //                Assert.IsTrue(messageBoxText.Text.Contains("Server started"), "Message 'Server started' was not found in the message box.");

    //                // Close the message box by pressing the "OK" button
    //                var okButtonCondition = new AndCondition(
    //                 serverAutomation.ConditionFactory.ByControlType(ControlType.Button),
    //                serverAutomation.ConditionFactory.ByName("OK")
    //                );
    //                var okButton = messageBox.FindFirstChild(okButtonCondition).AsButton();

    //            }
    //        }
    //    }
    //}




    //[TestClass]
    //public class ChatBoxTests
    //{
    //    private const string ApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Client\bin\Debug\net7.0-windows\Client_PC01.exe";
    //    private const string ServerApplicationPath = @"C:\Users\EthanNguyen\source\repos\[Project IV]Group 3\Shopping App\Server\Server\bin\Debug\net7.0-windows\Server.exe";

    //    [TestMethod]
    //    public void AttemptConnection_ShouldDisplayConnectedMessage()
    //    {
    //        // Launch the server and start it
    //        using (var serverApp = Application.Launch(ServerApplicationPath))
    //        {
    //            using (var serverAutomation = new UIA3Automation())
    //            {
    //                var serverWindow = serverApp.GetMainWindow(serverAutomation);
    //                var startServerButton = serverWindow.FindFirstDescendant(cf => cf.ByText("StartServer")).AsButton();

    //                // Check if the Invoke pattern is available and invoke the button
    //                var invokePattern = startServerButton.Patterns.Invoke.PatternOrDefault;
    //                startServerButton.Click();

    //            }

    //            using (var clientApp = Application.Launch(ApplicationPath))
    //            {
    //                using (var clientAutomation = new UIA3Automation())
    //                {
    //                    var clientWindow = clientApp.GetMainWindow(clientAutomation);
    //                    var connectButton = clientWindow.FindFirstDescendant(cf => cf.ByText("Connect")).AsButton();

    //                    Assert.IsNotNull(connectButton, "Connect button not found on the window.");

    //                    // Invoke the connect button if the pattern is available
    //                    connectButton.Patterns.Invoke.PatternOrDefault?.Invoke();

    //                    // Define a condition for finding the message box
    //                    var condition = new AndCondition(
    //                        clientAutomation.ConditionFactory.ByControlType(ControlType.Window),
    //                        clientAutomation.ConditionFactory.ByClassName("#32770"),
    //                        clientAutomation.ConditionFactory.ByProperty(AutomationElement.IsOffscreenProperty, false)
    //                    );

    //                    // Wait for the message box to appear using FlaUI's Retry pattern
    //                    var messageBox = Retry.WhileNull(() =>
    //                    {
    //                        // Attempt to find the message box as a new window
    //                        return clientAutomation.GetDesktop().FindFirstChild(condition);
    //                    }, timeout: TimeSpan.FromSeconds(5), throwOnTimeout: false).Result;

    //                    Assert.IsNotNull(messageBox, "MessageBox did not appear after clicking connect.");

    //                    // Check if the message box contains the expected text
    //                    var messageBoxText = messageBox.FindFirstChild(cf => cf.ByControlType(ControlType.Text)).AsLabel();
    //                    Assert.IsTrue(messageBoxText.Text.Contains("Connected to server."), "Message 'Connected to server.' was not found in the message box.");

    //                    // Close the message box by pressing the "OK" button
    //                    var okButton = messageBox.FindFirstChild(cf => cf.ByControlType(ControlType.Button) && cf.ByName("OK")).AsButton();
    //                    okButton?.Invoke();
    //                }
    //            }
    //        }
    //    }
    //}
}


