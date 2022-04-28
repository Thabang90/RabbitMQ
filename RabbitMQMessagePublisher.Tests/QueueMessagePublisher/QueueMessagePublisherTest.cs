using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Client;
using RabbitMQMessagePublisher.QueuePublisher;

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
        public void BuildQueueConnection_HasValidConnection_ConnectionNotNull()
        {
            var factory = new ConnectionFactory();
            var result = factory.CreateConnection();
            var message = "Hello My name is, Thabang";

            target.BuildQueueConnection(message);

            Assert.IsNotNull(result);
        }
    }
}
