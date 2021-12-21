using System;
using System.Collections.Generic;

namespace Chopi.API.Models
{
    public class SignalRClient
    {
        private List<string> _groups;

        public string ConnectionId { get; private set; }
        public IEnumerable<string> Groups => _groups;

        public SignalRClient(string connectionId)
        {
            _groups = new();
            ConnectionId = connectionId;
        }

        public void AddToGroup(string groupname)
        {
            if (IsMemberGroup(groupname) is false)
                _groups.Add(groupname);
        }

        public void RemoveFromGroup(string groupname)
        {
            if (IsMemberGroup(groupname))
                _groups.Remove(groupname);
        }

        public bool IsMemberGroup(string groupname)
        {
            return _groups.Exists(e => e.Equals(groupname));
        }

        public void Disconected(string conId)
        {
            if (conId == ConnectionId)
            {
                ConnectionId = null;
                _groups.Clear();
            }
            else
            {
                throw new ArgumentException($"Приходящий {nameof(conId)} не соответствует {nameof(ConnectionId)}");
            }
        }
    }
}
