using Chopi.Modules.Share.Abstracts;
using System;

namespace Chopi.DesktopApp.Models.Interfaces
{
    /// <summary>
    /// Описывает api service, который принимает предикат для фильтрации данных со стороны сервера
    /// </summary>
    /// <typeparam name="TObj">Возвращаемые тип объекта</typeparam>
    /// <typeparam name="TRequest">Объект запроса</typeparam>
    internal interface IApiDataService<TObj, TRequest> : IApiService
        where TObj : class
        where TRequest : IDataRequest<TObj>
    {
        /// <summary>
        /// Установка нового предиката
        /// </summary>
        /// <param name="predicate">Предикат фильтрации</param>
        public void SetPredicate(Func<TObj, bool> predicate);
    }
}
