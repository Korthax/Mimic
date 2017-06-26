using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class DecimalKnownType : SimpleKnownType<decimal>
    {
        public override object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return valueFactory.Int(0, 9999) + (decimal)valueFactory.Double(0, 1);
        }
    }
}