using System;
using System.Linq.Expressions;

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
        /// Выражение фильтрации
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Начало списка (используется для IEnumerable<T>.Skip(int count))
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Количество объектов в списке (используется для IEnumerable<T>.Take(int count))
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Получение выражения, которое сейчас стоит
        /// </summary>
        public Func<T, bool> GetFunc();

        /// <summary>
        /// Установка нового выражения
        /// </summary>
        public void SetExpression(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Стоит ли выражение в данный момент
        /// </summary>
        public bool IsSetExpression();
    }
}
