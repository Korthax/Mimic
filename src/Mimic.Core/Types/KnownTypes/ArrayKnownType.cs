using System;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class ArrayKnownType : IImitableType, IJudgeableType
    {
        public void SetOn(PropertyInfo propertyInfo, object returnObject, IObjectFactory objectFactory, IValueFactory valueFactory)
        {
            var elementType = propertyInfo.PropertyType.GetElementType();
            var arraySize = valueFactory.Int(1, 5);
            var instance = Array.CreateInstance(elementType, arraySize);

            for (var i = 0; i < arraySize; i++)
                instance.SetValue(objectFactory.For(elementType), i);
            
            var setter = propertyInfo.GetSetMethod(true);
            setter?.Invoke(returnObject, new object[] { instance });
        }

        public bool IsInstanceOf(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (type == typeof(string) || typeInfo.GetInterface("IEnumerable`1") == null)
                return false;

            return  typeInfo.BaseType == typeof(Array);
        }

        public bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory)
        {
            var type = object1.GetType();
            var elementType = type.GetElementType();

            var array1 = object1 as Array;
            var array2 = object2 as Array;

            if (array1 == null || array2 == null)
                return false;

            if (array1.Length != array2.Length)
                return false;

            for (var i = 0; i < array1.Length; i++)
            {
                if (!comparisonFactory.Compare(array1.GetValue(i), array2.GetValue(i), elementType))
                    return false;
            }

            return true;
        }

        public object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type)
        {
            return type.GetTypeInfo().BaseType == typeof(Array)
                ? Array.CreateInstance(type.GetElementType(), valueFactory.Int(1, 10))
                : Array.CreateInstance(type, valueFactory.Int(1, 10));
        }
    }
}