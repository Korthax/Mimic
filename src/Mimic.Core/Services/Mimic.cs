using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Services.Factories;
using Mimic.Core.Types.KnownProperties;
using Mimic.Core.Types.KnownTypes;
using Mimic.Core.Types.Simple;

namespace Mimic.Core.Services
{
    public sealed class Mimic<T>
    {
        private readonly KnownPropertyFactory _knownPropertyFactory;
        private readonly ImitableTypeFactory _imitableTypeFactory;
        private readonly List<IKnownProperty> _knownProperties;
        private readonly List<IImitableType> _knownTypes;
        private readonly MimicSettings _settings;

        public Mimic() : this(new MimicSettings()) { }

        public Mimic(MimicSettings settings)
        {
            _settings = settings;
            _knownPropertyFactory = new KnownPropertyFactory(new ObjectActivator());
            _imitableTypeFactory = new ImitableTypeFactory(new ObjectActivator());

            var assemblyAdapter = new AssemblyAdapter(typeof(ImitableTypeFactory).GetTypeInfo().Assembly);
            _knownProperties = new List<IKnownProperty>(_knownPropertyFactory.From(assemblyAdapter));
            _knownTypes = new List<IImitableType>(_imitableTypeFactory.From(assemblyAdapter, settings));
        }

        public void Register(IAssembly assembly)
        {
            _knownProperties.AddRange(_knownPropertyFactory.From(assembly));
            _knownTypes.AddRange(_imitableTypeFactory.From(assembly, _settings));
        }

        public Mimic<T> Register(object value)
        {
            _knownTypes.Add(new CustomKnownType(value));
            return this;
        }

        public Mimic<T> Register<TV>(string propertyName, TV value)
        {
            _knownProperties.Add(new CustomKnownProperty<TV>(propertyName, value));
            return this;
        }

        public T CreateInstance()
        {
            return (T)ObjectFactory.From(_knownTypes, _knownProperties, _settings).For(typeof(T));
        }

        public T Distort(T instance)
        {
            var objectFactory = ObjectFactory.From(_knownTypes, _knownProperties, _settings);
            objectFactory.Map(instance, typeof(T).GetTypeInfo().GetProperties());
            return instance;
        }
    }
}