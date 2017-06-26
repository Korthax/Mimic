using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Services.Strategies.Accessors
{
    internal class FieldAccessorStrategy : IAccessorStrategy
    {
        public List<IAccessor> GetAccessorsFor(Type type)
        {
            return new List<IAccessor>(type.GetTypeInfo().GetFields().Select(x => new FieldAccessor(x)));
        }

        private class FieldAccessor : IAccessor
        {
            private readonly FieldInfo _fieldInfo;

            public FieldAccessor(FieldInfo fieldInfo)
            {
                _fieldInfo = fieldInfo;
            }

            public object GetValueFrom(object @object)
            {
                return _fieldInfo.GetValue(@object);
            }

            public Type Type()
            {
                return _fieldInfo.FieldType;
            }
        }
    }
}