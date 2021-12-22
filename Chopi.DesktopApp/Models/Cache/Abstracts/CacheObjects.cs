using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using Chopi.DesktopApp.Models.ApiSignalR.Interfaces;
using Chopi.DesktopApp.Models.Cache.Interfaces;
using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share;
using Chopi.Modules.Share.Abstracts;
using Chopi.Modules.Share.HubInterfaces.Abstracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Cache.Abstracts
{
    /// <summary>
    /// Класс контейнер, который хранит данные типа <see cref="T"/> и выполняет операции CRUD
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    internal class CacheObjects<T> : ICacheObjects<T>
        where T : CachedObject
    {
        private MemoryCache _cache;
        private MemoryCacheEntryOptions _entryOptions;

        public CacheObjects()
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
        public Task UpdateInCache(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Добавление объекта в кеш
        /// </summary>
        public void AddToCache(T entity)
        {
            _cache.Set(entity.Id, entity, _entryOptions);
        }
        
    }
}
