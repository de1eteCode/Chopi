using Chopi.Modules.Share.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Interfaces
{
    /// <summary>
    /// Описывает класс, через который можно получить данные с сервера
    /// </summary>
    internal interface IData : INetworkClient
    {
        /// <summary>
        /// Используется для получение объекта
        /// </summary>
        /// <typeparam name="TObj">Тип возвращаемого объекта</typeparam>
        /// <typeparam name="TRequst">Тип объекта запроса</typeparam>
        /// <param name="service">Сервис для данного зпроса</param>
        /// <returns>Объект с данными</returns>
        public Task<TObj?> ObjectServiceAsync<TObj, TRequst>(IApiDataService<TObj, TRequst> service)
            where TObj : class
            where TRequst : IDataRequest<TObj>;

        /// <summary>
        /// Используется для получение коллекции объектов
        /// </summary>
        /// <typeparam name="TObj">Тип объекта в коллекции</typeparam>
        /// <typeparam name="TRequst">Тип объекта запроса</typeparam>
        /// <param name="service">Сервис для данного зпроса</param>
        /// <returns>Коллекция объектов с данными</returns>
        public Task<IEnumerable<TObj>?> CollectionServiceAsync<TObj, TRequst>(IApiDataService<TObj, TRequst> service)
            where TObj : class
            where TRequst : IDataRequest<TObj>;
    }
}
