using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using Chopi.Modules.Share;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Interfaces
{
    /// <summary>
    /// Описывает класс, через который можно получить данные с сервера
    /// </summary>
    internal interface IDataSource : INetworkClient
    {
        /// <summary>
        /// Используется для получение объекта
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого объекта</typeparam>
        /// <param name="service">Сервис для данного зпроса</param>
        /// <returns>Объект с данными</returns>
        public Task<T?> ObjectServiceAsync<T, TRequest>(IApiDataService<T, TRequest> service)
            where T : class
            where TRequest : DataRequestCollection<T>;

        /// <summary>
        /// Используется для получение коллекции объектов
        /// </summary>
        /// <typeparam name="T">Тип объекта в коллекции</typeparam>
        /// <param name="service">Сервис для данного зпроса</param>
        /// <returns>Коллекция объектов с данными</returns>
        public Task<IEnumerable<T>?> CollectionServiceAsync<T, TRequest>(IApiDataService<T, TRequest> service)
            where T : class
            where TRequest : DataRequestCollection<T>;
    }
}
