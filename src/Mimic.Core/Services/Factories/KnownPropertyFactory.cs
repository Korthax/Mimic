using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Types.KnownProperties;
using Mimic.Core.Types.Simple;

namespace Mimic.Core.Services.Factories
{
    internal interface IKnownPropertyFactory
    {
        List<IKnownProperty> From(IAssembly assembly);
    }

    internal class KnownPropertyFactory : IKnownPropertyFactory
    {
        private readonly IObjectActivator _objectActivator;

        public KnownPropertyFactory(IObjectActivator objectActivator)
        {
            _objectActivator = objectActivator;
        }

        public List<IKnownProperty> From(IAssembly assembly)
        {
            var result = new List<IKnownProperty>();
            foreach (var typeInAssembly in assembly.GetTypes())
            {
                var typeInfo = typeInAssembly.GetTypeInfo();
                if (!typeInfo.IsClass || typeInfo.IsAbstract || typeInAssembly == typeof(CustomKnownProperty<>))
                    continue;

                foreach (var @interface in typeInfo.GetInterfaces())
                {
                    if(@interface != typeof (IKnownProperty))
                        continue;

                    result.Add((IKnownProperty)_objectActivator.Create(typeInAssembly));
                }
            }

            return result;
        }
    }
}