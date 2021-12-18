using Chopi.Modules.Share.ExpressionConverter;
using System;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share
{
    /// <summary>
    /// Описывает модель, которая используется для запроса данных с сервера
    /// </summary>
    /// <typeparam name="T">Тип объекта для фильтрации</typeparam>
    public class DataRequest<T>
        where T : class
    {
        [JsonIgnore]
        private bool? _haveFunc = null;

        /// <summary>
        /// Начало списка (используется для IEnumerable<T>.Skip(int count))
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; }

        /// <summary>
        /// Количество объектов в списке (используется для IEnumerable<T>.Take(int count))
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
        
        /// <summary>
        /// Выражение фильтрации
        /// </summary>
        [JsonPropertyName("expression")]
        public string Expression { get; set; }

        [JsonConstructor]
        public DataRequest(int start, int count, string expression)
        {
            Start = start;
            Count = count;
            Expression = TryGetFunc(expression) is not null ? expression : string.Empty;
        }
        
        public DataRequest(int start, int count, Expression<Func<T, bool>> expression)
            : this(start, count, GetExpressionString(expression)) { }

        public DataRequest(int start, int count)
            : this(start, count, string.Empty) { }

        /// <summary>
        /// Получение выражения, которое сейчас стоит
        /// </summary>
        public Func<T, bool> GetFunc()
        {
            if (IsSetExpression())
            {
                return
                    DynamicExpressionParser.ParseLambda<T, bool>(ParsingConfig.Default, false, Expression, new object[0])
                    .Compile();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Установка нового выражения
        /// </summary>
        public void SetExpression(Expression<Func<T, bool>> expression)
        {
            Expression = GetExpressionString(expression);
        }

        /// <summary>
        /// Стоит ли выражение в данный момент
        /// </summary>
        public bool IsSetExpression()
        {
            if (_haveFunc is not null && _haveFunc.Value is false)
            {
                return false;
            }

            if (string.IsNullOrEmpty(Expression))
            {
                _haveFunc = false;
            }
            else
            {
                _haveFunc = true;
            }

            return _haveFunc.Value;
        }

        private static Func<T, bool> TryGetFunc(string expression)
        {
            try
            {
                return
                    DynamicExpressionParser.ParseLambda<T, bool>(ParsingConfig.Default, false, expression, new object[0])
                    .Compile();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string GetExpressionString(Expression<Func<T, bool>> expression)
        {
            var exprSimple = expression?.Simplify();
            return exprSimple?.ToString() ?? string.Empty;
        }
    }
}
