namespace Serialization.Serializers;

using System.Linq.Expressions;
using System.Reflection;

public static class ExpressionTree
{
    public static T DeepCopyExpressionTrees<T>(T input)
    {
        return GenerateDeepCopy<T>()(input);
    }

    public static Func<T, T> GenerateDeepCopy<T>()
    {
        ParameterExpression inputParameter = Expression.Parameter(typeof(T), "input");
        
        List<MemberBinding> memberBindings = new List<MemberBinding>();

        foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
        {
            MemberExpression propertyExpression = Expression.Property(inputParameter, propertyInfo);

            if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
            {
                MethodInfo copyMethod = typeof(ExpressionTree)
                    .GetMethod(nameof(ExpressionTree.DeepCopyExpressionTrees))
                    .MakeGenericMethod(propertyInfo.PropertyType);

                MethodCallExpression propertyCopyExpression = Expression.Call(copyMethod, propertyExpression);

                memberBindings.Add(Expression.Bind(propertyInfo, propertyCopyExpression));
            }
            else
            {
                memberBindings.Add(Expression.Bind(propertyInfo, propertyExpression));
            }
        }

        MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(T)), memberBindings);

        return Expression.Lambda<Func<T, T>>(memberInitExpression, inputParameter).Compile();
    }
}