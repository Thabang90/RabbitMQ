using RabbitMQMessagePublisher.MessageString.Interfaces;
using RabbitMQMessagePublisher.QueuePublisher;
using System;

namespace RabbitMQMessagePublisher.MessageString
{
    public class BuildMessageString : IBuildMessageString
    {
        private readonly IQueueMessagePublisher queueMessagePublisher;
        public BuildMessageString(IQueueMessagePublisher queueMessagePublisher)
        {
            this.queueMessagePublisher = queueMessagePublisher;
        }

        public void CreateMessageString()
        {
            Console.Write("Please Enter Name:");
            var inputName = Console.ReadLine();

            var message = $"Hello my name is,{inputName}";

            queueMessagePublisher.BuildQueueConnection(message);
        }
    }
}
