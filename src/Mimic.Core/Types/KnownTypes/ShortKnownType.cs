using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class ShortKnownType : SimpleKnownType<short>
    {
        public override object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return (short)valueFactory.Int(short.MinValue, short.MaxValue);
        }
    }
}