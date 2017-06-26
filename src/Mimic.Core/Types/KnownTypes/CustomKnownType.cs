using System;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class CustomKnownType : IImitableType
    {
        private readonly object _value;

        public CustomKnownType(object value)
        {
            _value = value;
        }

        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new[] { _value });
        }

        public bool IsInstanceOf(Type type)
        {
            return type == _value.GetType();
        }

        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return _value;
        }
    }
}