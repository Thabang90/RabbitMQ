using RabbitMQMessagePublisher.MessageString;
using RabbitMQMessagePublisher.MessageString.Interfaces;
using RabbitMQMessagePublisher.QueuePublisher;
using System;

namespace RabbitMQMessagePublisher
{
    public class MainMessageBuilder
    {
        public static void Main(string[] args)
        {
            IQueueMessagePublisher queueMessagePublisher = new QueueMessagePublisher();
            IBuildMessageString buildMessageString = new BuildMessageString(queueMessagePublisher);

            var again = false;
            do
            {
                buildMessageString.CreateMessageString();
                again = TryAgainPrompt();
            } while (again);

            Console.WriteLine();
            Console.WriteLine("...Bye!");
            Console.Read();
        }

        private static bool TryAgainPrompt()
        {
            Console.WriteLine();
            Console.Write("Try Again? Y/N: ");

            var userInput = Console.ReadLine().ToLower();

            var tryAgain = userInput == "y";
            return tryAgain;
        }
    }
}
