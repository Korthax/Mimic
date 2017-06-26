using System;
using System.Reflection;
using Mimic.Core.Services.Factories;
using Mimic.Core.Services.Strategies.Exceptions;

namespace Mimic.Core.Types.KnownTypes
{
    internal class ExceptionKnownType : IImitableType, IJudgeableType
    {
        private readonly IExceptionCreationStrategy _exceptionStrategy;

        public ExceptionKnownType(IExceptionCreationStrategy exceptionStrategy)
        {
            _exceptionStrategy = exceptionStrategy;
        }

        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new[] { NewFrom(objectFactory, valueFactory, propertyInfo.PropertyType) });
        }

        public bool IsInstanceOf(Type type)
        {
            return type == typeof(Exception);
        }

        public bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory)
        {
            return object1.Equals(object2);
        }

        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return _exceptionStrategy.CreateNew(valueFactory);
        }
    }
}