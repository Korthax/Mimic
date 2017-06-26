using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class ListKnownType : IImitableType, IJudgeableType
    {
        private static readonly Type ListType = typeof(List<>);

        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var propertyTypeInfo = propertyInfo.PropertyType.GetTypeInfo();
            var genericType = propertyTypeInfo.GetGenericArguments()[0];
            var actualListType = ListType.MakeGenericType(genericType);

            var instance = (IList)Activator.CreateInstance(actualListType);

            for (var i = 0; i < valueFactory.Int(1, 5); i++)
                instance.Add(objectFactory.For(genericType));

            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new object[] { instance });
        }

        public bool IsInstanceOf(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (type == typeof(string) || typeInfo.GetInterface("IEnumerable`1") == null || typeInfo.BaseType == typeof(Array))
                return false;

            return type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory)
        {
            var typeInfo = object1.GetType().GetTypeInfo();
            var elementType = typeInfo.GetGenericArguments()[0];

            var array1 = object1 as IList;
            var array2 = object2 as IList;

            if (array1 == null || array2 == null)
                return false;

            if (array1.Count != array2.Count)
                return false;

            for (var i = 0; i < array1.Count; i++)
            {
                if (!comparisonFactory.Compare(array1[i], array2[i], elementType))
                    return false;
            }

            return true;
        }
        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return Activator.CreateInstance(type);
        }
    }
}