using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;
using System.Threading;
using RoutingCommon;

namespace RoutingWCF
{
    public static class MainClass
    {
        public static void Main(string[] args)
        {
            var routingHost = new ServiceHost(typeof(RoutingService));
            routingHost.Open();

            while (true)
            {
                var discoveryProxy = new DiscoveryClient(new UdpDiscoveryEndpoint());
                var findCriteria = new FindCriteria(typeof(IRoutingService))
                {
                    Duration = new TimeSpan(0, 0, 5),
                    MaxResults = 10
                };

                findCriteria.Scopes.Add(new Uri("http://temp/discoverability"));

                var discoveryResponse = discoveryProxy.Find(findCriteria);
                var endpoints = (from endpointData in discoveryResponse.Endpoints
                    let binding = new NetTcpBinding
                    {
                        Security = {Mode = SecurityMode.None}
                    }
                    let address = endpointData.Address
                    let contract = ContractDescription.GetContract(typeof (IRequestReplyRouter))
                    select new ServiceEndpoint(contract, binding, address)).ToList();

                var routingConfiguration = new RoutingConfiguration();
                routingConfiguration.FilterTable.Add(new MatchAllMessageFilter(), endpoints);
                routingHost.Description.Behaviors.Remove<RoutingBehavior>();
                routingHost.Description.Behaviors.Add(new RoutingBehavior(routingConfiguration));

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            Console.WriteLine("Routing host was started!");
            Console.ReadLine();
        }
    }
}
