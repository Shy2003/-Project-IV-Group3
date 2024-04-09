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


