// https://stackoverflow.com/questions/53676292/how-can-i-get-a-string-from-linq-expression

using System;
using System.Linq.Expressions;

namespace Chopi.Modules.Share.ExpressionConverter
{
    public static class ExpressionExtensions
    {
        public static Expression Simplify(this Expression expression)
        {
            var searcher = new ParameterlessExpressionSearcher();
            searcher.Visit(expression);
            return new ParameterlessExpressionEvaluator(searcher.ParameterlessExpressions).Visit(expression);
        }

        public static Expression<T> Simplify<T>(this Expression<T> expression)
        {
            return (Expression<T>)Simplify((Expression)expression);
        }

        public static Func<T> Simplify<T>(this Func<T> expression)
        {
            return (Func<T>)Simplify((Func<T>)expression);
        }
    }
}
