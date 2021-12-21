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
            SetExpression(expression);
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
            Expression = TryGetString(expression);
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
        /// Конвертация выражения из <see cref="string"/> в <see cref="Func{TEntity, TResult}<"/>
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
        /// Конвертация выражения из <see cref="Expression{TDelegate}"/> в <see cref="string"/>
        /// </summary>
        protected static string TryGetString<TDelegate>(Expression<TDelegate> expression)
        {
            try
            {
                if (expression is null)
                    return string.Empty;

                var body =
                    expression.Body
                    .ToString()
                    .Replace("AndAlso", "&&")
                    .Replace("OrElse", "||");

                var param =
                    expression.Parameters[0]
                    .ToString();

                return param + " => " + body;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
