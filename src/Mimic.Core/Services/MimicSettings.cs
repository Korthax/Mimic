using Mimic.Core.Services.Factories;
using Mimic.Core.Services.Tracing;
using Mimic.Core.Types.Enums;

namespace Mimic.Core.Services
{
    public sealed class MimicSettings
    {
        public ITracer Tracer { get; set; }
        public IValueFactory ValueFactory { get; set; }
        public bool MockExceptions { get; set; }
        public AccessorStrategy AccessorStrategy { get; set; }

        public MimicSettings()
        {
            Tracer = new NoTracer();
            ValueFactory = new RandomValueFactory();
        }
    }
}