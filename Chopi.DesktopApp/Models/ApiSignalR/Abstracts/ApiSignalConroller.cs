using Chopi.DesktopApp.Models.Interfaces;
using Chopi.DesktopApp.Service;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Chopi.Modules.Share.HubInterfaces.Abstracts;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypedSignalR.Client;

namespace Chopi.DesktopApp.Models.ApiSinalR.Abstracts
{
    abstract class ApiSignalConroller<TEntity, TInterface>
        where TEntity : class
        where TInterface : class, IBaseHubActions<TEntity>
    {
        public event Action<string> Error;

        private readonly string _urlSub;

        protected readonly Configuration _cfg;
        protected readonly HubConnection _hub;
        protected readonly TInterface _responser;

        public ApiSignalConroller(TInterface responser, string urlHub, string urlSub)
        {
            _urlSub = urlSub;

            _cfg = Configuration.GetInstance();
            _hub = new HubConnectionBuilder().WithUrl(_cfg.HttpServerAddress + "/" + urlHub).Build();

            _responser = responser;
        }

        public async Task Start()
        {
            RegisterHub();
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

        protected abstract void RegisterHub();
    }
}
