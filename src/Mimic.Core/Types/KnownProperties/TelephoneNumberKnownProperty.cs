using System.Text;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownProperties
{
    internal class TelephoneNumberKnownProperty : SimpleKnownProperty<string>
    {
        public override string Value(IValueFactory valueFactory)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < 11; i++)
                stringBuilder.Append(valueFactory.Int(0, 9));
            return stringBuilder.ToString();
        }

        public override bool Matches(string propertyName)
        {
            return propertyName.ToLower().EndsWith("phonenumber");
        }
    }
}