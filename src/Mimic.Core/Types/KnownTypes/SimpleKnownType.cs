using System;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal abstract class SimpleKnownType<T> : IImitableType, IJudgeableType
    {
        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new[] { NewFrom(objectFactory, valueFactory, propertyInfo.PropertyType) });
        }

        public bool AreEqual<TT>(TT object1, TT object2, IComparisonFactory comparisonFactory)
        {
            return object1.Equals(object2);
        }

        public bool IsInstanceOf(Type type)
        {
            return type == typeof(T);
        }

        public abstract object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null);
    }
}