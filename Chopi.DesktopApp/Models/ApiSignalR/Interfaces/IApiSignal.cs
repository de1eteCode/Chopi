using Chopi.Modules.Share.HubInterfaces.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiSignalR.Interfaces
{
    internal interface IApiSignal<TEntity, TInterface>
        where TEntity : class
        where TInterface : class, IBaseHubActions<TEntity>
    {
        /// <summary>
        /// Запуск прослушивания и подписки на сервис
        /// </summary>
        /// <returns></returns>
        Task Start();

        /// <summary>
        /// Остановки прослушивания и отписки с сервиса
        /// </summary>
        /// <returns></returns>
        Task Stop();
    }
}
