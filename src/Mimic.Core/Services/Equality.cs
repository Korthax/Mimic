using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Services.Factories;
using Mimic.Core.Types.KnownTypes;
using Mimic.Core.Types.Simple;

namespace Mimic.Core.Services
{
    public class Equality
    {
        private readonly JudgeableTypeFactory _judgeableTypeFactory;
        private readonly List<IJudgeableType> _knownTypes;
        private readonly MimicSettings _settings;

        public Equality(MimicSettings settings)
        {
            _settings = settings;
            _judgeableTypeFactory = new JudgeableTypeFactory(new ObjectActivator());

            var assemblyAdapter = new AssemblyAdapter(typeof(IJudgeableType).GetTypeInfo().Assembly);
            _knownTypes = new List<IJudgeableType>(_judgeableTypeFactory.From(assemblyAdapter, settings));
        }

        public void Register(IAssembly assembly)
        {
            _knownTypes.AddRange(_judgeableTypeFactory.From(assembly, _settings));
        }

        public Equality Register(IJudgeableType value)
        {
            _knownTypes.Add(value);
            return this;
        }

        public bool Judge<T>(T object1, T object2)
        {
            return ComparisonFactory.From(_knownTypes, _settings).Compare(object1, object2, typeof(T));
        }
    }
}