using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Chopi.Modules.Share;

namespace Chopi.DesktopApp.Models.Abstracts
{
    /// <summary>
    /// Класс, который управляет данными типа <see cref="T"/> и выполняет операции CRUD
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    internal class CacheObjects<T, TRequest>
        where T : CachedObject
        where TRequest : DataRequest<T>
    {
        private MemoryCache _cache;
        private MemoryCacheEntryOptions _entryOptions;

        private IApiDataService<T, TRequest> _service;
        private IDataSource _source;

        public CacheObjects(IApiDataService<T,TRequest> service)
        {
            _cache = new MemoryCache(new MemoryCacheOptions()
            {
                SizeLimit = 256,
                ExpirationScanFrequency = TimeSpan.FromMinutes(5) // Задание минимального временого интервала проверок на наличие объектов с истекшим сроком действия
            });

            _entryOptions = new MemoryCacheEntryOptions()
            {
                Size = 1,
                SlidingExpiration = TimeSpan.FromMinutes(10),
                Priority = 0
            };

            _service = service;
            _source = NetworkClient.GetInstance<IDataSource>();
        }

        /// <summary>
        /// Загрузка коллекции данных с сервера
        /// </summary>
        public async Task LoadCollection(int start, int count, Expression<Func<T, bool>> expression = null)
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
                Add(item);
            }
        }
        
        /// <summary>
        /// Получение объекта из кеша
        /// </summary>
        public T? GetItem(Guid id)
        {
            _cache.TryGetValue(id, out var item);
            return (T?)item;
        }

        /// <summary>
        /// Обновление данных в кеше
        /// </summary>
        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Добавление объекта в кеш
        /// </summary>
        public void Add(T entity)
        {
            _cache.Set(entity.Id, entity, _entryOptions);
        }
    }
}
