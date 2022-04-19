using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqMessageConsumer.DisplayMessage
{
    public class DisplayReceivedMessage : IDisplayReceivedMessage
    {
        public string DisplayIncomingMessage(string message)
        {
            var pos = message.IndexOf(",");
            var name = message.Substring(pos + 1).Trim('"');
            var outputMessage = "";
            if (!string.IsNullOrEmpty(name))
            {
                outputMessage = $"Hello {name}, I am your father!";
                Console.WriteLine(outputMessage);
            }
            else
            {
                throw new ArgumentNullException("Please Ensure you have Entered your Name!");
            }

            return outputMessage;
        }
    }
}
