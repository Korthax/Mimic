using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Services.Strategies.Exceptions
{
    internal class MockStrategy : IExceptionCreationStrategy
    {
        public Exception CreateNew(IValueFactory valueFactory)
        {
            var innerException = new Exception(valueFactory.String(15));
            return new Exception(valueFactory.String(15), innerException);
        }
    }
}