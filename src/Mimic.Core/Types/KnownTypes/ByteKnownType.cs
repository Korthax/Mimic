using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class ByteKnownType : SimpleKnownType<byte>
    {
        public override object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return valueFactory.Bytes(1)[0];
        }
    }
}