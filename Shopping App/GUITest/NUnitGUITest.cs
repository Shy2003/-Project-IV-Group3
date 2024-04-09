using NUnit.Framework;
using NUnit.Extensions.Forms;
using Client_PC01;

[TestFixture]
public class ChatBoxTests : NUnitFormTest
{
    private ChatBox chatBox;

    [SetUp]
    public void Setup()
    {
        chatBox = new ChatBox();
        chatBox.Show();
    }

    [TearDown]
    public void TearDown()
    {
        chatBox.Close();
    }

    [Test]
    public void TestSendMessageButtonEnabled()
    {
        var btnSendMessage = new ButtonTester("btnSendMessage", chatBox);
        Assert.IsFalse(btnSendMessage.Properties.Enabled);

        // Simulate connecting to the server
        var btnConnect = new ButtonTester("guna2Button1", chatBox);
        btnConnect.Click();

        Assert.IsTrue(btnSendMessage.Properties.Enabled);
    }

    // Add more tests here...
}
