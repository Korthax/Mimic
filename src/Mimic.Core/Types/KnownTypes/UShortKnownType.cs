using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class UShortKnownType : SimpleKnownType<ushort>
    {
        public override object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return BitConverter.ToUInt16(valueFactory.Bytes(2), 0);
        }
    }
}