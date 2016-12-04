using System;

namespace RoutingCommon
{
    public sealed class SimpleRoutingService : IRoutingService
    {
        public void SayHelloToServer(string serverName)
        {
            Console.WriteLine($"Somebody said hello to me ^_^ by the way my name is {serverName}");
        }

        public void SayHelloToEveryone()
        {
            Console.WriteLine("Somebody said hello to everyone ^_^");
        }
    }
}
