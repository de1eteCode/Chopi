using Chopi.API.Hubs.Abstracts;
using Chopi.API.Models;
using Chopi.Modules.Share.HubInterfaces;

namespace Chopi.API.Hubs
{
    public class AutopartHub : BaseHub<IAutopartHubAction>
    {
        public AutopartHub(SignalRConnections connections) : base(connections)
        {
        }
    }
}
