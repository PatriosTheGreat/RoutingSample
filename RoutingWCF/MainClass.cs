using System;
using System.ServiceModel;
using System.ServiceModel.Routing;

namespace RoutingWCF
{
    public static class MainClass
    {
        public static void Main(string[] args)
        {
            var routingHost = new ServiceHost(typeof(RoutingService));
            routingHost.Open();

            Console.WriteLine("Routing host was started!");
            Console.ReadLine();
        }
    }
}
