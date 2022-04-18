using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMqMessageConsumer.DisplayMessage;
using System;

namespace RabbitMqMessageConsumer.Tests
{
    [TestClass]
    public class DisplayReceivedMessageTest
    {
        [TestMethod]
        public void DisplayIncomingMessage_ValidMessageReceived_DisplaysCorrectMessage()
        {
            var Expectedmessage = "Hello my name is, Thabang";
            var ExpectedResults = "Hello  Thabang, I am your father!";

            var actualMessage = DisplayReceivedMessage.DisplayIncomingMessage(Expectedmessage);

            Assert.AreEqual(ExpectedResults, actualMessage);
        }

    }
}
