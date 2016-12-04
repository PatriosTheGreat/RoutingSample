using System;
using System.ServiceModel;
using System.ServiceModel.Routing;
using RoutingCommon;

namespace FirstServer
{
    public sealed class Program
    {
        static void Main(string[] args)
        {
            var routingHost = new ServiceHost(typeof(SimpleRoutingService));

            routingHost.Open();

            Console.WriteLine("Services started on Console Host 1 . Press [Enter] to exit.");
            Console.ReadLine();

            routingHost.Close();
        }
    }
}
