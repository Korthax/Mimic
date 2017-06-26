using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Services.Strategies.Accessors
{
    internal class PropertyAccessorStrategy : IAccessorStrategy
    {
        public List<IAccessor> GetAccessorsFor(Type type)
        {
            return new List<IAccessor>(type.GetTypeInfo().GetProperties().Select(x => new PropertyAccessor(x)));
        }

        private class PropertyAccessor : IAccessor
        {
            private readonly PropertyInfo _propertyInfo;

            public PropertyAccessor(PropertyInfo propertyInfo)
            {
                _propertyInfo = propertyInfo;
            }

            public object GetValueFrom(object @object)
            {
                return _propertyInfo.GetValue(@object, null);
            }

            public Type Type()
            {
                return _propertyInfo.PropertyType;
            }
        }
    }
}