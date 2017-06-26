using System;

namespace Mimic.Core.Types.Errors
{
    public class MimickerException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public MimickerException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}