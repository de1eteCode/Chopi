using Chopi.Modules.Share.Abstracts;
using Chopi.Modules.Share.ExpressionConverter;
using System;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Chopi.Modules.Share
{
    public class DataRequest<T> : IDataRequest<T>
        where T : class
    {
        [JsonIgnore]
        private bool? _haveFunc = null;

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

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
            : this(start, count, TryGetExpressionString(expression)) { }

        public DataRequest(int start, int count)
            : this(start, count, string.Empty) { }

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

        public void SetExpression(Expression<Func<T, bool>> expression)
        {
            Expression = GetExpressionString(expression);
        }

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
            var exprSimple = expression.Simplify();
            return exprSimple.ToString();
        }

        private static string TryGetExpressionString(Expression<Func<T, bool>> expression)
        {
            try
            {
                return GetExpressionString(expression);

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
