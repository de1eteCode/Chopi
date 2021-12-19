using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share
{
    /// <summary>
    /// Описывает модель, которая используется для запроса коллекции данных с сервера
    /// </summary>
    /// <typeparam name="T">Тип объекта для фильтрации</typeparam>
    public class DataRequestCollection<T> : DataRequest<T>
        where T : class
    {
        /// <summary>
        /// Начало списка (используется для IEnumerable<T>.Skip(int count))
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; private set; }

        /// <summary>
        /// Количество объектов в списке (используется для IEnumerable<T>.Take(int count))
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; private set; }
        
        /// <summary>
        /// Выражение сортировки.
        /// </summary>
        [JsonPropertyName("ordering")]
        public string Ordering { get; private set; }

        /// <summary>
        /// Данный конструктор не рекомендуеться для использования. Создан для JsonConstructor.
        /// </summary>
        [JsonConstructor]
        public DataRequestCollection(int start, int count, string expression, string ordering)
            : base(expression)
        {
            Start = start;
            Count = count;
            Ordering = TryGetFunc<IQueryable<T>, IOrderedQueryable<T>>(ordering) is not null ? ordering : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start">Количество записей для пропуска</param>
        /// <param name="count">Количество записей для выборки</param>
        /// <param name="expression">Выражение для фильтрации</param>
        /// <param name="ordering">Выражение для сортировки</param>
        public DataRequestCollection(int start, int count, Expression<Func<T, bool>> expression, Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> ordering)
            : this(start, count, TryGetString(expression), TryGetString(ordering)) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start">Количество записей для пропуска</param>
        /// <param name="count">Количество записей для выборки</param>
        /// <param name="expression">Выражение поиска</param>
        public DataRequestCollection(int start, int count, Expression<Func<T, bool>> expression)
            : this(start, count, TryGetString(expression), null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start">Количество записей для пропуска</param>
        /// <param name="count">Количество записей для выборки</param>
        public DataRequestCollection(int start, int count)
            : this(start, count, string.Empty, string.Empty) { }

        /// <summary>
        /// Установка количества записей для пропуска
        /// </summary>
        public void SetStart(int start)
        {
            Start = start;
        }

        /// <summary>
        /// Установка количества записей для выборки
        /// </summary>
        public void SetCount(int count)
        {
            Count = count;
        }

        /// <summary>
        /// Установка диапазона страниц
        /// </summary>
        /// <param name="start">Количество записей для пропуска</param>
        /// <param name="count">Количество записей для выбборки</param>
        public void SetPage(int start, int count)
        {
            SetStart(start);
            SetCount(count);
        }

        /// <summary>
        /// Получение выражения сортировки, которое сейчас стоит (<see cref="Ordering"/>)
        /// </summary>
        /// <returns></returns>
        public Func<IQueryable<T>, IOrderedQueryable<T>> GetOrdering()
        {
            if (IsSetOrdering())
            {
                return TryGetFunc<IQueryable<T>, IOrderedQueryable<T>>(Ordering);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Установка нового выражения сортировки (<see cref="Ordering"/>)
        /// </summary>
        public void SetOrdering(Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> expression)
        {
            Ordering = TryGetString(expression);
        }

        /// <summary>
        /// Стоит ли выражение сортировки в данный момент (<see cref="Ordering"/>)
        /// </summary>
        public bool IsSetOrdering()
        {
            if (string.IsNullOrEmpty(Ordering))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
