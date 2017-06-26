using System;
using System.Reflection;
using Mimic.Core.Services.Factories;
using Mimic.Core.Types.KnownTypes;

namespace Mimic.Core.UnitTests.Framework
{
    internal class SimpleObjectKnownType : IImitableType
    {
        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
        }

        public bool IsInstanceOf(Type type)
        {
            return type == typeof(SimpleObject);
        }

        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return new SimpleObject
            {
                Decimal = 5.45m,
                Int = 5,
                String = "sgnksdjgs"
            };
        }
    }
}