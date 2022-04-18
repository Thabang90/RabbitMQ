using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using RabbitMQMessagePublisher;
using RabbitMQMessagePublisher.QueuePublisher;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Collections;
using System.IO;

namespace RabbitM_MessagePublisher.Tests
{
    [TestClass]
    public class QueueMessagePublisherTest
    {
        private QueueMessagePublisher target;

        [TestInitialize]
        public void Setup()
        {
            target = new QueueMessagePublisher();
        }

        [TestCleanup]
        public void Teardown()
        {
            target = null;
        }

        [TestMethod]
        public void BuildQueueConnection_HasValidConnection_ReturnsConnection()
        {
            var factory = new ConnectionFactory();
            var result = factory.CreateConnection();
            var message = "Hello My name is, Thabang";

            target.BuildQueueConnection(message);

            Assert.IsNotNull(result);
        }


    }
}
