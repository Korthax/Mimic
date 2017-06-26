using System;
using System.Collections.Generic;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Services.Strategies.Accessors
{
    internal class DualAccessorStrategy : IAccessorStrategy
    {
        private readonly PropertyAccessorStrategy _propertyAccessorStrategy;
        private readonly FieldAccessorStrategy _fieldAccessorStrategy;

        public DualAccessorStrategy(PropertyAccessorStrategy propertyAccessorStrategy, FieldAccessorStrategy fieldAccessorStrategy)
        {
            _propertyAccessorStrategy = propertyAccessorStrategy;
            _fieldAccessorStrategy = fieldAccessorStrategy;
        }

        public List<IAccessor> GetAccessorsFor(Type type)
        {
            var accessors = new List<IAccessor>();
            accessors.AddRange(_propertyAccessorStrategy.GetAccessorsFor(type));
            accessors.AddRange(_fieldAccessorStrategy.GetAccessorsFor(type));
            return accessors;
        }
    }
}