using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMessageConsumer.DisplayMessage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RabbitMqMessageConsumer.Tests
{
    [TestClass]
    public class MainMessageConsumerTest
    {
        private MainMessageConsumer target;
        private Mock<IDisplayReceivedMessage> displayReceivedMessage;

        private Mock<IConnection> connection;
        private Mock<EventingBasicConsumer> consumer;
        private Mock<IModel> channel;

        [TestInitialize]
        public void Setup()
        {
            SetupMocks();
            displayReceivedMessage = new Mock<IDisplayReceivedMessage>();
            target = new MainMessageConsumer();
        }

        [TestCleanup]
        public void Teardown()
        {
            target = null;
            displayReceivedMessage = null;
            connection = null;
            consumer = null;
            channel = null;
        }

        private void SetupMocks()
        {

            connection = new Mock<IConnection>();
            connection.Setup(o => o.CreateModel()).Verifiable();

            channel = new Mock<IModel>();
            consumer = new Mock<EventingBasicConsumer>(channel);
            channel.Setup(o => o.QueueDeclare(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>())).Verifiable();

            var messageToDisplay = "Hello my name is Thabang";
            displayReceivedMessage = new Mock<IDisplayReceivedMessage>();
            displayReceivedMessage.Setup(o => o.DisplayIncomingMessage(It.IsAny<string>())).Returns(messageToDisplay);
        }

        [TestMethod]
        public void ConsumeMessage_ValidMessageReceived_DisplayReceivedMessageVerified()
        {
            var stringReader = new StringReader("Hello my name is, Thabang");
            Console.SetIn(stringReader);

            target.ConsumeMessage();

            displayReceivedMessage.VerifyAll();
        }

        [TestMethod]
        public void ConsumeMessage_ValidMockedFields_FieldsNotNull()
        {

            var stringReader = new StringReader("Hello my name is, Thabang");
            Console.SetIn(stringReader);

            target.ConsumeMessage();

            Assert.IsNotNull(connection);
            Assert.IsNotNull(consumer);
            Assert.IsNotNull(channel);
        }
    }
}
