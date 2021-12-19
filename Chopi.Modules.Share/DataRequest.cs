using Chopi.Modules.Share.ExpressionConverter;
using System;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share
{
    /// <summary>
    /// Описывает модель, которая используется для запроса данных одного объекта с сервера
    /// </summary>
    /// <typeparam name="T">Тип объекта для фильтрации</typeparam>
    public class DataRequest<T>
        where T : class
    {
        /// <summary>
        /// Выражение фильтрации
        /// </summary>
        [JsonPropertyName("expression")]
        public string Expression { get; private set; }

        /// <summary>
        /// Данный конструктор не рекомендуеться для использования. Создан для JsonConstructor.
        /// </summary>
        [JsonConstructor]
        public DataRequest(string expression)
        {
            Expression = TryGetFunc<T, bool> (expression) is not null ? expression : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression">Выражение для фильтрации</param>
        public DataRequest(Expression<Func<T, bool>> expression)
        {
            Expression = GetExpressionString(expression);
        }

        /// <summary>
        /// Получение выражения фильтрации, которое сейчас стоит (<see cref="Expression"/>)
        /// </summary>
        public Func<T, bool> GetExpression()
        {
            if (IsSetExpression())
            {
                return TryGetFunc<T, bool>(Expression);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Установка нового выражения фильтрации (<see cref="Expression"/>)
        /// </summary>
        public void SetExpression(Expression<Func<T, bool>> expression)
        {
            Expression = GetExpressionString(expression);
        }

        /// <summary>
        /// Стоит ли выражение фильтрации в данный момент (<see cref="Expression"/>)
        /// </summary>
        public bool IsSetExpression()
        {
            if (string.IsNullOrEmpty(Expression))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Конвертация выражения строкового типа в <see cref="Func{TEntity, TResult}<"/>
        /// </summary>
        protected static Func<TEntity, TResult> TryGetFunc<TEntity, TResult>(string expression)
        {
            try
            {
                return
                    DynamicExpressionParser.ParseLambda<TEntity, TResult>(ParsingConfig.Default, false, expression, new object[0])
                    .Compile();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Конвертация выражения <typeparamref name="TFunc"/> в строку
        /// </summary>
        protected static string GetExpressionString<TFunc>(Expression<TFunc> expression)
        {
            var exprSimple = expression?.Simplify();
            return exprSimple?.ToString() ?? string.Empty;
        }
    }
}
