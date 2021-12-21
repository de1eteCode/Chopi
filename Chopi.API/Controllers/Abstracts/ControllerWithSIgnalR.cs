using Chopi.API.Models;
using Chopi.Modules.Share.HubInterfaces.Abstracts;
using Chopi.Modules.Share.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.Abstracts
{
    public abstract class ControllerWithSignalR<THub, TInterface, TEntity> : Controller
        where THub : Hub<TInterface>
        where TInterface : class, IBaseHubActions<TEntity>
        where TEntity : class
    {
        protected abstract string _groupName { get; }
        protected readonly IHubContext<THub, TInterface> _hub;
        private readonly SignalRConnections _connections;

        protected ControllerWithSignalR(IHubContext<THub, TInterface> hub, SignalRConnections connections)
        {
            _hub = hub;
            _connections = connections;
        }

        /// <summary>
        /// Подписка на обновление данных.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("sub")]
        public async Task<IActionResult> Subscription([FromBody] SubscribeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _connections.AddToGroup(model.Key, _groupName);
            await _hub.Groups.AddToGroupAsync(model.Key, _groupName);

            return Ok();
        }

        /// <summary>
        /// Отписка от группы. Не является обязательным, т.к. обновления в котроллере происходят по одной группе, а отписка происходит ещё при дисконекте от хаба
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("unsub")]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscribeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _connections.RemoveFromGroup(model.Key, _groupName);
            await _hub.Groups.RemoveFromGroupAsync(model.Key, _groupName);

            return Ok();
        }

        /// <summary>
        /// Уведомление подписанных клиентов о добавлении элемента.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual async Task AddEntity(TEntity entity)
        {
            await _hub.Clients.Group(_groupName).Add(entity);
        }

        /// <summary>
        /// Уведомление подписанных клиентов о обновлении элемента
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns
        protected virtual async Task UpdateEntity(TEntity entity)
        {
            await _hub.Clients.Group(_groupName).Update(entity);
        }
    }
}
