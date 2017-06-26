using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    internal class LongKnownType : SimpleKnownType<long>
    {
        public override object NewFrom(IObjectFactory objectFactory, IValueFactory valueFactory, Type type = null)
        {
            return BitConverter.ToInt64(valueFactory.Bytes(8), 0);;
        }
    }
}