using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMessageConsumer.Consumer;
using RabbitMqMessageConsumer.DisplayMessage;
using System;
using System.Collections.Generic;
using System.IO;

namespace RabbitMqMessageConsumer.Tests.Consumer
{
    [TestClass]
    public class QueueMessageConsumerTest
    {
        private QueueMessageConsumer target;
        private Mock<IDisplayReceivedMessage> displayReceivedMessage;
        private Mock<IConnection> connection;
        private Mock<EventingBasicConsumer> consumer;
        private Mock<IModel> channel;

        [TestInitialize]
        public void Setup()
        {
            this.SetUpMocks();
            this.target = new QueueMessageConsumer(this.displayReceivedMessage.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.displayReceivedMessage = null;
            connection = null;
            consumer = null;
            channel = null;
        }

        private void SetUpMocks()
        {
            this.displayReceivedMessage = new Mock<IDisplayReceivedMessage>();

            connection = new Mock<IConnection>();
            connection.Setup(o => o.CreateModel()).Verifiable();

            channel = new Mock<IModel>();
            consumer = new Mock<EventingBasicConsumer>(channel);
            channel.Setup(o => o.QueueDeclare(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>())).Verifiable();
        }

        [TestMethod]
        public void ConsumeMessage_MockedDisplayReceivedMessage_DisplayIncomingMessageVerified()
        {
            var stringReader = new StringReader("Hello my name is, Thabang");
            Console.SetIn(stringReader);

            target.ConsumeMessage();

            this.displayReceivedMessage.VerifyAll();
        }

        [TestMethod]
        public void ConsumeMessage_InvalidMockedDisplayReceivedMessage_DisplayIncomingMessageNeverCalled()
        {
            var stringReader = new StringReader("Hello my name is, Thabang");
            Console.SetIn(stringReader);

            this.displayReceivedMessage.Setup(o => o.DisplayIncomingMessage(It.IsAny<string>())).Returns(default(string));

            target.ConsumeMessage();

            this.displayReceivedMessage.Verify(o => o.DisplayIncomingMessage(It.IsAny<string>()), Times.Never);
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
