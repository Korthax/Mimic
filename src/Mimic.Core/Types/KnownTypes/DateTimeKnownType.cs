using System;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class DateTimeKnownType : IImitableType, IJudgeableType
    {
        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new[] { NewFrom(objectFactory, valueFactory, propertyInfo.PropertyType) });
        }

        public bool IsInstanceOf(Type type)
        {
            return type == typeof(DateTime);
        }

        public bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory)
        {
            return object1.Equals(object2);
        }

        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            var from = DateTime.Now.AddYears(-valueFactory.Int(0, 50));
            var difference = DateTime.Today - from;
            return from.AddDays(valueFactory.Int(0, difference.Days));
        }
    }
}