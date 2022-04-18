using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQMessagePublisher;
using RabbitMQMessagePublisher.QueuePublisher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RabbitM_MessagePublisher.Tests
{
    [TestClass]
    public class MainMessageBuilderTest
    {
        private MainMessageBuilder target;
        private Mock<IQueueMessagePublisher> messageBuilder;

        [TestInitialize]
        public void Setup()
        {
            target = new MainMessageBuilder();
            messageBuilder = new Mock<IQueueMessagePublisher>();
        }

        [TestCleanup]
        public void Teardown()
        {
            target = null;
            messageBuilder = null;
        }

        [TestMethod]
        public void BuildMessageString_MockedQueueMessagePublisher_VerifiesExpectedResults()
        {
            var stringReader = new StringReader("Hello my name is, Thabang");
            Console.SetIn(stringReader);

            target.BuildMessageString();

            messageBuilder.VerifyAll();
        }
    }
}
