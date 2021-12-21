using Chopi.API.Hubs.Abstracts;
using Chopi.API.Models;
using Chopi.Modules.Share.HubInterfaces;

namespace Chopi.API.Hubs
{
    public class CarHub : BaseHub<ICarHubActions>
    {
        public CarHub(SignalRConnections connections) : base(connections)
        {
        }
    }
}
