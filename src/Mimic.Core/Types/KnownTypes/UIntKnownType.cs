using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class UIntKnownType : SimpleKnownType<uint>
    {
        public override object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return BitConverter.ToUInt32(valueFactory.Bytes(4), 0);
        }
    }
}