using System.ServiceModel;
using System.Windows;
using RoutingCommon;

namespace RoutingClient
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var channelFactory = new ChannelFactory<IRoutingService>("routingService");
            var routingService = channelFactory.CreateChannel();
            routingService.SayHelloToServer(ServerName.Text);
        }

        private void HelloEveryone(object sender, RoutedEventArgs e)
        {
            var channelFactory = new ChannelFactory<IRoutingService>("routingServiceBroadcast");
            var routingService = channelFactory.CreateChannel();
            routingService.SayHelloToEveryone();
        }
    }
}
