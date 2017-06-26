using System;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class UriKnownType : IImitableType, IJudgeableType
    {
        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new[] { NewFrom(objectFactory, valueFactory, propertyInfo.PropertyType) });
        }

        public bool IsInstanceOf(Type type)
        {
            return type == typeof(Uri);
        }

        public bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory)
        {
            return object1.Equals(object2);
        }

        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return new Uri(string.Format("http://www.{0}.com", valueFactory.String(15)));
        }
    }
}