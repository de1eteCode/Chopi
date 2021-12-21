using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chopi.API.Hubs
{
    public class UserHub : Hub<IUserHubActions>
    {
    }
}
