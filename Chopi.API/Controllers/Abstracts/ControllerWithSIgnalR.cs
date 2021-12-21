using Chopi.API.Hubs;
using Chopi.Modules.Share.HubInterfaces.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.Abstracts
{
    public abstract class ControllerWithSIgnalR<THub, TInterface, TEntity> : Controller
        where THub : Hub<TInterface>
        where TInterface : class, IBaseHubActions<TEntity>
        where TEntity : class
    {
        protected readonly IHubContext<THub, TInterface> _hub;

        protected ControllerWithSIgnalR(IHubContext<THub, TInterface> hub)
        {
            _hub = hub;
        }

        protected virtual async Task AddEntity(TEntity entity)
        {
            await _hub.Clients.All.Add(entity);
        }

        protected virtual async Task UpdateEntity(TEntity entity)
        {
            await _hub.Clients.All.Update(entity);
        }
    }
}
