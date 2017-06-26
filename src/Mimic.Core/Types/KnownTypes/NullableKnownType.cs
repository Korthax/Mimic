using System;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class NullableKnownType : IImitableType, IJudgeableType
    {
        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new[] { objectFactory.For(propertyInfo.GetType()) });
        }

        public bool IsInstanceOf(Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory)
        {
            return object1.Equals(object2);
        }

        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return objectFactory.For(type.GetTypeInfo().GetGenericArguments()[0]);
        }
    }
}