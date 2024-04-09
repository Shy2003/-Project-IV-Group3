using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

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

        [TestMethod]
        //public void AttemptConnection_ShouldDisplayConnectedMessage()
        //{
        //    // Start the application
        //    var app = FlaUI.Core.Application.Launch("path/to/your/Client_PC01.exe");
        //    using (var automation = new UIA3Automation())
        //    {
        //        var window = app.GetMainWindow(automation);

        //        // Find and click the "Connect" button
        //        var connectButton = window.FindFirstDescendant(cf => cf.ByText("Connect")).AsButton();
        //        connectButton.Click();

        //        // Check if the "Connected to server." message box is displayed
        //        var messageBox = window.ModalWindows.Find(x => x.Name == "MessageBox");
        //        Assert.IsNotNull(messageBox);
        //        var messageBoxText = messageBox.FindFirstDescendant(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Text)).AsLabel().Text;
        //        Assert.AreEqual("Connected to server.", messageBoxText);

        //        // Close the message box and the application
        //        messageBox.FindFirstDescendant(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Button)).AsButton().Click();
        //        app.Close();
        //    }
        //}

    }
}
