using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMqMessageConsumer.DisplayMessage;
using System;

namespace RabbitMqMessageConsumer.Tests
{
    [TestClass]
    public class DisplayReceivedMessageTest
    {
        private IDisplayReceivedMessage displayMessage;

        [TestInitialize]
        public void Setup()
        {
            displayMessage = new DisplayReceivedMessage();
        }

        [TestCleanup]
        public void Teardown()
        {
            displayMessage = null;
        }

        [TestMethod]
        public void DisplayIncomingMessage_ValidMessageReceived_DisplaysCorrectMessage()
        {
            var Expectedmessage = "Hello my name is, Thabang";
            var ExpectedResults = "Hello  Thabang, I am your father!";

            var actualMessage = displayMessage.DisplayIncomingMessage(Expectedmessage);

            Assert.AreEqual(ExpectedResults, actualMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DisplayIncomingMessage_MessageReceivedHasNoName_ArgumentNullExceptionThrown()
        {
            var Expectedmessage = "Hello my name is,";
            displayMessage.DisplayIncomingMessage(Expectedmessage);
        }
    }
}
