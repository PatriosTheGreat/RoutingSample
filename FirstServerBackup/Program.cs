using System;
using System.ServiceModel;
using RoutingCommon;

namespace FirstServerBackup
{
    public sealed class Program
    {
        static void Main(string[] args)
        {
            var routingHost = new ServiceHost(typeof(SimpleRoutingService));

            routingHost.Open();

            Console.WriteLine("Services started on Console Host Backup. Press [Enter] to exit.");
            Console.ReadLine();

            routingHost.Close();
        }
    }
}
