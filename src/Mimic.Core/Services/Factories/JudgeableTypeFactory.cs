using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Types.KnownTypes;
using Mimic.Core.Types.Simple;

namespace Mimic.Core.Services.Factories
{
    internal class JudgeableTypeFactory : IKnownTypeFactory<IJudgeableType>
    {
        private readonly IObjectActivator _objectActivator;

        public JudgeableTypeFactory(IObjectActivator objectActivator)
        {
            _objectActivator = objectActivator;
        }

        public List<IJudgeableType> From(IAssembly assembly, MimicSettings settings)
        {
            var result = new List<IJudgeableType>();
            foreach (var typeInAssembly in assembly.GetTypes())
            {
                var typeInfo = typeInAssembly.GetTypeInfo();
                if (!typeInfo.IsClass || typeInfo.IsAbstract || typeInAssembly == typeof(CustomKnownType) || typeInAssembly == typeof(ExceptionKnownType))
                    continue;

                foreach (var @interface in typeInfo.GetInterfaces())
                {
                    if (@interface != typeof(IJudgeableType)) 
                        continue;

                    result.Add(_objectActivator.Create<IJudgeableType>(typeInAssembly));
                    break;
                }
            }
            
            return result;
        }
    }
}