using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownProperties
{
    public interface IKnownProperty
    {
        bool Is(PropertyInfo propertyInfo);
        void SetOn(PropertyInfo propertyInfo, object returnObject, IValueFactory valueFactory);
    }

    internal class PostCodeKnownProperty : SimpleKnownProperty<string>
    {
        public override string Value(IValueFactory valueFactory)
        {
            var area = valueFactory.String(2);
            var district = valueFactory.Int(10, 99);
            var sector = valueFactory.Int(1, 9);
            var unitA = StringOtherThan(valueFactory, 1, "C", "I", "K", "M", "O", "V");
            var unitB = StringOtherThan(valueFactory, 1, "C", "I", "K", "M", "O", "V");
            return $"{area}{district}{sector}{unitA}{unitB}".ToUpper();
        }

        private static string StringOtherThan(IValueFactory valueFactory, int length, params string[] excludeStrings)
        {
            var randomString = valueFactory.String(length);
            var excludeList = new List<string>();
            excludeStrings.ToList().ForEach(exclude => excludeList.Add(exclude.ToUpper()));

            while (excludeList.Contains(randomString.ToUpper()))
                randomString = valueFactory.String(length);

            return randomString;
        }

        public override bool Matches(string propertyName)
        {
            return propertyName.Equals("postcode", StringComparison.OrdinalIgnoreCase);
        }
    }
}