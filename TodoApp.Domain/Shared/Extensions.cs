using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Shared
{
    public static class Extensions
    {
        public static bool HasProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
        public static Expression<Func<T, object>> ToLambda<T>(this string propertyName)
        {
            var propertyNames = propertyName.Split('.');
            var parameter = Expression.Parameter(typeof(T));
            Expression body = parameter;
            foreach (var propName in propertyNames)
                body = Expression.Property(body, propName);
            return Expression.Lambda<Func<T, object>>(Expression.Convert(body, typeof(object)), parameter);
        }
    }
}
