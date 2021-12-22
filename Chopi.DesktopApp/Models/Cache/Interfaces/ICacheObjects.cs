using Chopi.Modules.Share.Abstracts;
using System;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Cache.Interfaces
{
    /// <summary>
    /// Описывает класс контейнер, который хранит данные типа <see cref="T"/> и выполняет операции CRUD
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    internal interface ICacheObjects<T>
        where T : CachedObject
    {
        /// <summary>
        /// Получение объекта из кеша
        /// </summary>
        T? GetItem(Guid id);

        /// <summary>
        /// Обновление данных в кеше
        /// </summary>
        Task UpdateInCache(T entity);

        /// <summary>
        /// Добавление объекта в кеш
        /// </summary>
        void AddToCache(T entity);
    }
}
