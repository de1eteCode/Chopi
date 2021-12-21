using Chopi.API.Hubs.Abstracts;
using Chopi.API.Models;
using Chopi.Modules.Share.HubInterfaces;

namespace Chopi.API.Hubs
{
    public class UserHub : BaseHub<IUserHubActions>
    {
        public UserHub(SignalRConnections connections) : base(connections)
        {
        }
    }
}
