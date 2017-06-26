using System;

namespace Mimic.Core.Services.Tracing
{
    public sealed class ConsoleTracer : ITracer
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}