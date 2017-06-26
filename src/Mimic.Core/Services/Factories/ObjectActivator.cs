using System;

namespace Mimic.Core.Services.Factories
{
    internal interface IObjectActivator
    {
        T Create<T>(Type type);
        object Create(Type type);
    }

    internal class ObjectActivator : IObjectActivator
    {
        public T Create<T>(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }

        public object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}