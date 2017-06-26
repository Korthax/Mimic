using System;

namespace Mimic.Core.Types.KnownTypes
{
    public interface IKnownType
    {
        bool IsInstanceOf(Type type);
    }
}