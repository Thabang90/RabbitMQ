using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMessageConsumer.Consumer.Interfaces;
using RabbitMqMessageConsumer.DisplayMessage;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqMessageConsumer.Consumer
{
    public class QueueMessageConsumer : IQueueMessageConsumer
    {
        private readonly IDisplayReceivedMessage displayReceivedMessage;
        public QueueMessageConsumer(IDisplayReceivedMessage displayReceivedMessage)
        {
            this.displayReceivedMessage = displayReceivedMessage;
        }

        public void ConsumeMessage()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("message-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                this.displayReceivedMessage.DisplayIncomingMessage(message);
            };

            channel.BasicConsume("message-queue", true, consumer);
            Console.ReadLine();
        }
    }
}
