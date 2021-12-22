using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using Chopi.DesktopApp.Models.ApiSignalR.Interfaces;
using Chopi.DesktopApp.Models.Cache.Interfaces;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share;
using Chopi.Modules.Share.Abstracts;
using Chopi.Modules.Share.HubInterfaces.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Cache.Abstracts
{
    internal class ManagerObjects<TEntity> : IBaseHubActions<TEntity>
        where TEntity : CachedObject
    {

        protected IApiSignal<TEntity, IBaseHubActions<TEntity>> _signal;
        private IApiDataService<TEntity, DataRequestCollection<TEntity>> _service;
        private IDataSource _source;
        private ICacheObjects<TEntity> _cacheObjects;

        public ManagerObjects(
            IApiDataService<TEntity, DataRequestCollection<TEntity>> service,
            IApiSignal<TEntity, ManagerObjects<TEntity>> signal)
        {
            _cacheObjects = new CacheObjects<TEntity>();

            _service = service;

            _source = NetworkClient.GetInstance<IDataSource>();
        }

        /// <summary>
        /// Загрузка коллекции данных с сервера
        /// </summary>
        public async Task LoadCollection(int start, int count, Expression<Func<TEntity, bool>> expression = null)
        {
            _service.SetPages(start, count);
            _service.SetPredicate(expression);
            var data = await _source.CollectionServiceAsync(_service);

            if (data is null)
            {
#if DEBUG
                throw new Exception("null data");
#else
                return;
#endif
            }

            foreach (var item in data)
            {
                _cacheObjects.AddToCache(item);
            }
        }

        /// <summary>
        /// Добавление элемента от сервера (callback)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Add(TEntity entity)
        {
            await Task.Run(() => _cacheObjects.AddToCache(entity));
        }

        /// <summary>
        /// Обновление элемента от сервера (callback)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(TEntity entity)
        {
            await Task.Run(() => _cacheObjects.UpdateInCache(entity));
        }
    }
}
