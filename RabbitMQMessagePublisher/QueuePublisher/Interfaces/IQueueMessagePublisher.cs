
namespace RabbitMQMessagePublisher.QueuePublisher
{
    public interface IQueueMessagePublisher
    {
        void BuildQueueConnection(string message);
    }
}
