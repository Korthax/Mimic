using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class ULongKnownType : SimpleKnownType<ulong>
    {
        public override object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return BitConverter.ToUInt64(valueFactory.Bytes(8), 0);
        }
    }
}