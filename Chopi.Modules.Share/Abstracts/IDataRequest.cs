using System;

namespace Chopi.Modules.Share.Abstracts
{
    /// <summary>
    /// Описывает модель, которая используется для запроса данных с сервера
    /// </summary>
    /// <typeparam name="T">Тип объекта для фильтрации</typeparam>
    public interface IDataRequest<T>
        where T : class
    {
        /// <summary>
        /// Предикат фильтрации
        /// </summary>
        public Func<T, bool> Predicate { get; set; }

        /// <summary>
        /// Начало списка (используется для IEnumerable<T>.Skip(int count))
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Количество объектов в списке (используется для IEnumerable<T>.Take(int count))
        /// </summary>
        public int Count { get; set; }
    }
}
