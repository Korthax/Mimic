using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Services.Strategies.Exceptions
{
    internal class IgnoreAllStrategy : IExceptionCreationStrategy
    {
        public Exception CreateNew(IValueFactory valueFactory)
        {
            return null;
        }
    }
}