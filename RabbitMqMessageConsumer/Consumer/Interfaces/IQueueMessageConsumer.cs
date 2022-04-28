using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqMessageConsumer.Consumer.Interfaces
{
    public interface IQueueMessageConsumer
    {
        void ConsumeMessage();
    }
}
