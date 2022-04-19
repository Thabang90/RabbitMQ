using RabbitMQMessagePublisher.QueuePublisher;
using System;

namespace RabbitMQMessagePublisher
{
    public class MainMessageBuilder
    {

        public static void Main(string[] args)
        {
            MainMessageBuilder msg = new MainMessageBuilder();
            var again = false;
            do
            {
                msg.BuildMessageString();
                again = TryAgainPrompt();
            } while (again);

            Console.WriteLine();
            Console.WriteLine("...Bye!");
            Console.Read();
        }

        public void BuildMessageString()
        {
            Console.Write("Please Enter Name:");
            var inputName = Console.ReadLine();

            var message = $"Hello my name is,{inputName}";

            IQueueMessagePublisher queueMessagePublisher = new QueueMessagePublisher();

            queueMessagePublisher.BuildQueueConnection(message);
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
