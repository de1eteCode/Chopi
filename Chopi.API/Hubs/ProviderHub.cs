using Chopi.API.Hubs.Abstracts;
using Chopi.API.Models;
using Chopi.Modules.Share.HubInterfaces;

namespace Chopi.API.Hubs
{
    public class ProviderHub : BaseHub<IProviderHubActions>
    {
        public ProviderHub(SignalRConnections connections) : base(connections)
        {
        }
    }
}
