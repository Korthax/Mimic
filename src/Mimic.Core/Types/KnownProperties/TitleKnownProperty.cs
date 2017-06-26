using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownProperties
{
    internal class TitleKnownProperty : SimpleKnownProperty<string>
    {
        public override string Value(IValueFactory valueFactory)
        {
            return valueFactory.Int(0, 1) == 1 ? "Mr" : "Mrs";
        }

        public override bool Matches(string propertyName)
        {
            return propertyName.Equals("title", StringComparison.OrdinalIgnoreCase);
        }
    }
}