using System.Collections.Generic;
using System.Linq;

namespace Chopi.API.Models
{
    public class SignalRConnections
    {
        private object _sync = new();
        private List<SignalRClient> _clients;

        public SignalRConnections()
        {
            _clients = new();
        }

        public void OnConnection(string conId)
        {
            lock (_sync)
            {
                _clients.Add(new SignalRClient(conId));
            }
        }

        public void OnDisconnection(string conId)
        {
            lock (_sync)
            {
                var client = GetClient(conId);
                if (client is not null)
                {
                    client.Disconected(conId);
                    _clients.Remove(client);
                }
            }
        }

        public void AddToGroup(string conId, string groupname)
        {
            lock (_sync)
            {
                var client = GetClient(conId);

                client.AddToGroup(groupname);
            }
        }

        public void AddToGroup(string conId, IEnumerable<string> groupnames)
        {
            lock (_sync)
            {
                var client = GetClient(conId);

                foreach (var group in groupnames)
                {
                    client.AddToGroup(group);
                }
            }
        }

        public void RemoveFromGroup(string conId, string groupname)
        {
            lock (_sync)
            {
                var client = GetClient(conId);

                client.RemoveFromGroup(groupname);
            }
        }

        public void RemoveFromGroup(string conId, IEnumerable<string> groupnames)
        {
            lock (_sync)
            {
                var client = GetClient(conId);

                foreach (var group in groupnames)
                {
                    client.RemoveFromGroup(group);
                }
            }
        }

        public bool IsMemberGroup(string conId, string groupname)
        {
            return GetClient(conId).IsMemberGroup(groupname);
        }

        private SignalRClient? GetClient(string conId)
        {
            return
                _clients.Where(e => e.ConnectionId == conId).FirstOrDefault();
        }
    }
}
