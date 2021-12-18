using Chopi.Modules.Share;
using System;
using System.Linq.Expressions;

namespace Chopi.DesktopApp.Models.Interfaces
{
    /// <summary>
    /// Описывает api service, который принимает предикат для фильтрации данных со стороны сервера
    /// </summary>
    /// <typeparam name="TObj">Возвращаемые тип объекта</typeparam>
    /// <typeparam name="TRequest">Объект запроса</typeparam>
    internal interface IApiDataService<TObj, TRequest> : IApiService
        where TObj : class
        where TRequest : DataRequest<TObj>
    {
        /// <summary>
        /// Установка нового предиката
        /// </summary>
        /// <param name="expression">Выражение фильтрации</param>
        public void SetPredicate(Expression<Func<TObj, bool>> expression);

        /// <summary>
        /// Установка диапазона данных
        /// </summary>
        /// <param name="start">Сколько пропустить</param>
        /// <param name="count">Количество записей</param>
        void SetPages(int start, int count);
    }
}
