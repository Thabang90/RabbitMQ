using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQMessagePublisher.QueuePublisher
{
    public interface IQueueMessagePublisher
    {
        void BuildQueueConnection(string message);
    }
}
