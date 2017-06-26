using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownProperties
{
    internal class CustomKnownProperty<T> : SimpleKnownProperty<T>
    {
        private readonly string _propertyName;
        private readonly T _value;

        public CustomKnownProperty(string propertyName, T value)
        {
            _propertyName = propertyName;
            _value = value;
        }

        public override T Value(IValueFactory valueFactory)
        {
            return _value;
        }

        public override bool Matches(string propertyName)
        {
            return propertyName.Equals(_propertyName, StringComparison.OrdinalIgnoreCase);
        }
    }
}