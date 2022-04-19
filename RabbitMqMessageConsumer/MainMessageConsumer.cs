using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMessageConsumer.DisplayMessage;
using System;
using System.Text;

namespace RabbitMqMessageConsumer
{
    public class MainMessageConsumer
    {
        private IDisplayReceivedMessage displayReceivedMessage;

        public static void Main(string[] args)
        {
            var messageConsumer = new MainMessageConsumer();
            messageConsumer.ConsumeMessage();
        }

        public void ConsumeMessage()
        {
            var message = "";

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
                message = Encoding.UTF8.GetString(body);

                displayReceivedMessage = new DisplayReceivedMessage();
                displayReceivedMessage.DisplayIncomingMessage(message);
            };

            channel.BasicConsume("message-queue", true, consumer);
            Console.ReadLine();
        }
    }
}
