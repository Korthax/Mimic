namespace Mimic.Core.Services.Tracing
{
    public sealed class NoTracer : ITracer
    {
        public void Log(string message)
        {
            
        }
    }
}