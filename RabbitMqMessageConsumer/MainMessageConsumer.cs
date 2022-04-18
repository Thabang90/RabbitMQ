using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMessageConsumer.DisplayMessage;
using System;
using System.Text;

namespace RabbitMqMessageConsumer
{
    public class MainMessageConsumer
    {
        public static void Main(string[] args)
        {
            ConsumeMessage();
        }

        private static void ConsumeMessage()
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
                DisplayReceivedMessage.DisplayIncomingMessage(message);
            };

            channel.BasicConsume("message-queue", true, consumer);
            Console.ReadLine();
        }
    }
}
