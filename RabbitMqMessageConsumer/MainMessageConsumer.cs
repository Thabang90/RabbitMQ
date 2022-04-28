using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMessageConsumer.Consumer;
using RabbitMqMessageConsumer.Consumer.Interfaces;
using RabbitMqMessageConsumer.DisplayMessage;
using System;
using System.Text;

namespace RabbitMqMessageConsumer
{
    public class MainMessageConsumer
    {
        public static void Main(string[] args)
        {
            IDisplayReceivedMessage displayReceivedMessage = new DisplayReceivedMessage();
            IQueueMessageConsumer queueMessageConsumer = new QueueMessageConsumer(displayReceivedMessage);

            queueMessageConsumer.ConsumeMessage();
        }
    }
}
