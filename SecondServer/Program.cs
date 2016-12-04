using System;
using System.ServiceModel;
using RoutingCommon;

namespace SecondServer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var routingHost = new ServiceHost(typeof(SimpleRoutingService));

            routingHost.Open();

            Console.WriteLine("Services started on Console Host 2 . Press [Enter] to exit.");
            Console.ReadLine();

            routingHost.Close();
        }
    }
}
