using System;
using System.Collections.Generic;
using Mimic.Core.Services.Tracing;
using Mimic.Core.Types.KnownTypes;

namespace Mimic.Core.Services.Factories
{
    public interface IComparisonFactory
    {
        bool Compare<T>(T object1, T object2, Type type);
    }

    internal class ComparisonFactory : IComparisonFactory
    {
        private readonly IAccessorStrategy _accessorStrategy;
        private readonly IList<IJudgeableType> _knownTypes;
        private readonly ITracer _tracer;

        public static ComparisonFactory From(IList<IJudgeableType> knownTypes, MimicSettings settings)
        {
            return new ComparisonFactory(knownTypes, settings.Tracer, AccessorStrategyFactory.From(settings));
        }

        private ComparisonFactory(IList<IJudgeableType> knownTypes, ITracer tracer, IAccessorStrategy accessorStrategy)
        {
            _knownTypes = knownTypes;
            _tracer = tracer;
            _accessorStrategy = accessorStrategy;
        }

        public bool Compare<T>(T object1, T object2, Type type)
        {
            if (ReferenceEquals(object1, object2))
            {
                _tracer.Log(string.Format("[Match] <Reference Equal> '{0}'", type.Name));
                return true;
            }

            foreach (var knownType in _knownTypes)
            {
                if (!knownType.IsInstanceOf(type))
                    continue;

                _tracer.Log(string.Format("[Match] <Known Type ({0})> '{1}'", knownType.GetType().Name, type.Name));
                return knownType.AreEqual(object1, object2, this);
            }

            _tracer.Log(string.Format("[No Match] <Unknown Type> '{0}'", type.Name));

            var accessors = _accessorStrategy.GetAccessorsFor(type);
            foreach (var accessor in accessors)
            {
                var value1 = accessor.GetValueFrom(object1);
                var value2 = accessor.GetValueFrom(object2);

                if (value1 == null && value2 == null)
                    continue;

                if (value1 == null || value2 == null)
                {
                    _tracer.Log(string.Format("[Failed] <Unknown Type> '{0}' ({{ {1} }} != {{{2}}})", type.Name, value1, value2));
                    return false;
                }

                if (!Compare(value1, value2, accessor.Type()))
                {
                    _tracer.Log(string.Format("[Failed] <Unknown Type> '{0}' ({{ {1} }} != {{{2}}})", type.Name, value1, value2));
                    return false;
                }
            }

            return true;
        }
    }

    internal interface IAccessorStrategy
    {
        List<IAccessor> GetAccessorsFor(Type type);
    }

    internal interface IAccessor
    {
        object GetValueFrom(object @object);
        Type Type();
    }
}