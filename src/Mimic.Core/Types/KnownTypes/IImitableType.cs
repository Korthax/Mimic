using System;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    public interface IImitableType : IKnownType
    {
        void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory);
        object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null);
    }
}