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
                    var mainWindow = app.GetAllTopLevelWindows(automation).FirstOrDefault(window => window.Title == "Client_PC01");
                    var chatButton = mainWindow.FindFirstDescendant(cf => cf.ByText("ChatButton")); 

                    chatButton?.AsButton().Click();

                    Thread.Sleep(1000); // Wait for the ChatBox to open
                    var chatBoxWindow = mainWindow.FindFirstDescendant(cf => cf.ByText("ChatBox"));
                    Assert.IsNotNull(chatBoxWindow, "ChatBox form was not opened.");
                }
            }
        }
    }
}
