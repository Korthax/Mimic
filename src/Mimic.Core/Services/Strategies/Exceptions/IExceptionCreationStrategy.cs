using System;
using Mimic.Core.Services.Factories;

namespace Mimic.Core.Services.Strategies.Exceptions
{
    internal interface IExceptionCreationStrategy
    {
        Exception CreateNew(IValueFactory valueFactory);
    }
}