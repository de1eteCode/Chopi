using Chopi.API.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chopi.API.Hubs.Abstracts
{
    public abstract class BaseHub<T> : Hub<T>
        where T : class
    {
        private SignalRConnections _connections;

        public BaseHub(SignalRConnections connections)
        {
            _connections = connections;
        }

        public override Task OnConnectedAsync()
        {
            _connections.OnConnection(GetCurrentConnectionId());
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connections.OnDisconnection(GetCurrentConnectionId());
            return base.OnDisconnectedAsync(exception);
        }

        private string GetCurrentConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
