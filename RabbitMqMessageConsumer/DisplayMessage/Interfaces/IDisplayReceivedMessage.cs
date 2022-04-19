using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqMessageConsumer.DisplayMessage
{
    public interface IDisplayReceivedMessage
    {
        string DisplayIncomingMessage(string message);
    }
}
