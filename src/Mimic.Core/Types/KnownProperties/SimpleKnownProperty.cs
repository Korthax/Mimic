using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownProperties
{
    internal abstract class SimpleKnownProperty<T> : IKnownProperty
    {
        public abstract T Value(IValueFactory valueFactory);
        public abstract bool Matches(string propertyName);

        public void SetOn(PropertyInfo propertyInfo, object returnObject, IValueFactory valueFactory)
        {
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new object[] { Value(valueFactory) });
        }

        public bool Is(PropertyInfo propertyInfo)
        {
            return Matches(propertyInfo.Name) && propertyInfo.PropertyType == typeof(T);
        }
    }
}