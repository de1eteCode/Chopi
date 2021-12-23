using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.Service;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiSinalR.Abstracts
{
    abstract class ApiSignalController<TEntity>
        where TEntity : class
    {
        public event EventHandler<TEntity> AddEvent;
        public event EventHandler<TEntity> UpdateEvent;
        public event Action<string> Error;

        private readonly string _urlSub;

        protected readonly HubConnection _hub;

        public ApiSignalController(string urlHub, string urlSub)
        {
            _urlSub = urlSub;

            _hub = new HubConnectionBuilder().WithUrl(Configuration.GetInstance().HttpServerAddress + "/" + urlHub).Build();

            _hub.On<TEntity>("Add", e => AddEvent?.Invoke(this, e));
            _hub.On<TEntity>("Update", e => UpdateEvent?.Invoke(this, e));
        }

        public async Task Start()
        {
            await _hub.StartAsync();
            var subResult = await SubscribeMe();

            if (subResult is false)
            {
                Error?.Invoke("Не удалось подписаться на обновления");
#if DEBUG
                throw new Exception("Subscribe service not accepted");
#endif
            }
        }

        public async Task Stop()
        {
            await _hub.StopAsync();
        }

        private async Task<bool> SubscribeMe()
        {
            var subClient = NetworkClient.GetInstance<ISubscriber>();
            return await subClient.Subscribe(_urlSub, _hub.ConnectionId);
        }
    }
}
