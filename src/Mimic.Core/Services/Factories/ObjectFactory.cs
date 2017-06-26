using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mimic.Core.Services.Tracing;
using Mimic.Core.Types.KnownProperties;
using Mimic.Core.Types.KnownTypes;

namespace Mimic.Core.Services.Factories
{
    public interface IObjectFactory
    {
        object For(Type type);
        void Map(object instance, IEnumerable<PropertyInfo> properties);
    }

    internal sealed class ObjectFactory : IObjectFactory
    {
        private readonly IList<IKnownProperty> _knownProperties;
        private readonly IList<IImitableType> _knownTypes;
        private readonly IValueFactory _valueFactory;
        private readonly ITracer _tracer;

        public static ObjectFactory From(IList<IImitableType> knownTypes, IList<IKnownProperty> knownProperties, MimicSettings settings)
        {
            return new ObjectFactory(knownTypes, knownProperties, settings.Tracer, settings.ValueFactory);
        }

        private ObjectFactory(IList<IImitableType> knownTypes, IList<IKnownProperty> knownProperties, ITracer tracer, IValueFactory valueFactory)
        {
            _knownTypes = knownTypes;
            _knownProperties = knownProperties;
            _tracer = tracer;
            _valueFactory = valueFactory;
        }

        public object For(Type type)
        {
            foreach (var knownType in _knownTypes)
            {
                if (!knownType.IsInstanceOf(type))
                    continue;

                _tracer.Log(string.Format("[Construct] <Known Type> '{0}'", type.FullName));
                return knownType.NewFrom(this, _valueFactory, type);
            }

            _tracer.Log(string.Format("[Construct] <Unknown Type> '{0}'", type.FullName));

            object instance;
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.GetConstructor(Type.EmptyTypes) != null || !typeInfo.GetConstructors().Any())
                instance = Activator.CreateInstance(type);
            else
            {
                var constructor = typeInfo.GetConstructors().OrderBy(x => x.GetParameters().Length).First();
                var constructorParametersInfos = constructor.GetParameters();
                instance = constructor.Invoke(constructorParametersInfos.Select(x => For(x.ParameterType)).ToArray());
            }

            Map(instance, typeInfo.GetProperties());

            return instance;
        }

        public void Map(object instance, IEnumerable<PropertyInfo> properties)
        {
            foreach (var childInfo in properties)
                Assign(childInfo, instance);
        }

        private void Assign(PropertyInfo propertyInfo, object returnObject)
        {
            foreach (var knownProperty in _knownProperties)
            {
                if (!knownProperty.Is(propertyInfo)) 
                    continue;

                _tracer.Log(string.Format("[Assign] <Known Property> '{0}' of '{1}'", propertyInfo.Name, returnObject.GetType().Name));
                knownProperty.SetOn(propertyInfo, returnObject, _valueFactory);
                return;
            }

            var propertyType = propertyInfo.PropertyType;

            foreach (var knownType in _knownTypes)
            {
                if (!knownType.IsInstanceOf(propertyType))
                    continue;

                _tracer.Log(string.Format("[Assign] <Known Type> '{0}' ('{1}' of '{2}')", propertyType.FullName, propertyInfo.Name, returnObject.GetType().Name));
                knownType.SetOn(propertyInfo, returnObject, this, _valueFactory);
                return;
            }

            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new[] { For(propertyType) });
        }
    }
}