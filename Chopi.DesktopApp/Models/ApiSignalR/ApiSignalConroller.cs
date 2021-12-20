using Chopi.DesktopApp.Service;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiSignalR
{
    abstract class ApiSignalConroller
    {
        protected readonly Configuration _cfg;
        protected readonly HubConnection _hub;

        public ApiSignalConroller(string uriHub)
        {
            _cfg = Configuration.GetInstance();
            _hub = new HubConnectionBuilder().WithUrl(_cfg + uriHub).Build();
        }
    }
}
