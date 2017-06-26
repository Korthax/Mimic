using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Services.Strategies.Exceptions;
using Mimic.Core.Types.KnownTypes;
using Mimic.Core.Types.Simple;

namespace Mimic.Core.Services.Factories
{
    internal interface IKnownTypeFactory<T>
    {
        List<T> From(IAssembly assembly, MimicSettings mimicSettings);
    }

    internal class ImitableTypeFactory : IKnownTypeFactory<IImitableType>
    {
        private readonly IObjectActivator _objectActivator;

        public ImitableTypeFactory(IObjectActivator objectActivator)
        {
            _objectActivator = objectActivator;
        }

        public List<IImitableType> From(IAssembly assembly, MimicSettings settings)
        {
            var result = new List<IImitableType>();
            foreach (var typeInAssembly in assembly.GetTypes())
            {
                var typeInfo = typeInAssembly.GetTypeInfo();
                if(!typeInfo.IsClass || typeInfo.IsAbstract || typeInAssembly == typeof(CustomKnownType) || typeInAssembly == typeof(ExceptionKnownType))
                    continue;

                foreach (var @interface in typeInfo.GetInterfaces())
                {
                    if (@interface != typeof (IImitableType)) 
                        continue;

                    result.Add(_objectActivator.Create<IImitableType>(typeInAssembly));
                    break;
                }
            }

            result.Add(new ExceptionKnownType(settings.MockExceptions ? new MockStrategy() : (IExceptionCreationStrategy)new IgnoreAllStrategy()));
            
            return result;
        }
    }
}