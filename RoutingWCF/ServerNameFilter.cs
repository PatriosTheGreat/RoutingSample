using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace RoutingWCF
{
    public sealed class ServerNameFilter : MessageFilter
    {
        public ServerNameFilter(string a)
        {
        }

        public override bool Match(MessageBuffer buffer)
        {
            return false;
        }

        public override bool Match(Message message)
        {
            return message.ToString()?.IndexOf("<serverName>" + "SecondServer" + "</serverName>", StringComparison.Ordinal) > -1;
        }
    }
}
