using System;
using Mimic.Core.Types.Enums;
using Mimic.Core.Types.Errors;

namespace Mimic.Core.Services.Errors
{
    public class ExceptionBecause
    {
        public static Exception UnknownAccessorStrategy(AccessorStrategy accessorStrategy)
        {
            return new MimickerException(ErrorCode.UnknownAccessorStrategy, string.Format("Unknown accessor strategy '{0}'", accessorStrategy));
        }
    }
}