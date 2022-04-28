using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQMessagePublisher.MessageString;
using RabbitMQMessagePublisher.QueuePublisher;
using System;
using System.IO;

namespace RabbitM_MessagePublisher.Tests.MessageString
{
    [TestClass]
    public class BuildMessageStringTest
    {
        private BuildMessageString target;
        private Mock<IQueueMessagePublisher> queueMessagePublisher;

        [TestInitialize]
        public void Setup()
        {
            this.queueMessagePublisher = new Mock<IQueueMessagePublisher>();
            this.target = new BuildMessageString(queueMessagePublisher.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.target = null;
            this.queueMessagePublisher = null;
        }

        [TestMethod]
        public void CreateMessageString_MockedQueueMessagePublisher_BuildQueueConnection()
        {
            var stringReader = new StringReader("Hello my name is, Thabang");
            Console.SetIn(stringReader);

            this.target.CreateMessageString();

            this.queueMessagePublisher.Verify(o => o.BuildQueueConnection(It.IsAny<string>()), Times.Once);
        }
    }
}
