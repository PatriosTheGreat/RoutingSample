using System.ServiceModel;

namespace RoutingCommon
{
    [ServiceContract]
    public interface IRoutingService
    {
        [OperationContract]
        void SayHelloToServer(string serverName);

        [OperationContract(IsOneWay = true, Action = "http://temp/broadcast")]
        void SayHelloToEveryone();
    }
}
