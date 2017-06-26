using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class DictionaryKnownType : IImitableType, IJudgeableType
    {
        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var propertyTypeInfo = propertyInfo.PropertyType.GetTypeInfo();
            var keyType = propertyTypeInfo.GetGenericArguments()[0];
            var valueType = propertyTypeInfo.GetGenericArguments()[1];

            var instance = (IDictionary)NewFrom(objectFactory, valueFactory, propertyInfo.PropertyType);

            for (var i = 0; i < valueFactory.Int(1, 5); i++)
            {
                try
                {
                    var key = objectFactory.For(keyType);
                    var value = objectFactory.For(valueType);
                    instance.Add(key, value);
                }
                catch (ArgumentException)
                {
                }
            }

            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new object[] { instance });
        }

        public bool IsInstanceOf(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (type == typeof(string) || typeInfo.GetInterface("IEnumerable`1") == null || typeInfo.BaseType == typeof(Array))
                return false;

            return type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        public bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory)
        {
            var dictionary1 = object1 as IDictionary;
            var dictionary2 = object2 as IDictionary;

            if(dictionary1 == null || dictionary2 == null)
                return false;

            if(dictionary1.Keys.Count != dictionary2.Keys.Count)
                return false;

            foreach(var key in dictionary1.Keys)
            {
                if(!dictionary2.Contains(key))
                    return false;

                var result = comparisonFactory.Compare(dictionary1[key], dictionary2[key], dictionary1[key].GetType());
                if(!result)
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