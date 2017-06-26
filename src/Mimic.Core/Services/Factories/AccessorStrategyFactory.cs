using Mimic.Core.Services.Errors;
using Mimic.Core.Services.Strategies.Accessors;
using Mimic.Core.Types.Enums;

namespace Mimic.Core.Services.Factories
{
    internal static class AccessorStrategyFactory
    {
        public static IAccessorStrategy From(MimicSettings mimicSettings)
        {
            switch(mimicSettings.AccessorStrategy)
            {
                case AccessorStrategy.Both:
                    return new DualAccessorStrategy(new PropertyAccessorStrategy(), new FieldAccessorStrategy());
                case AccessorStrategy.Fields:
                    return new FieldAccessorStrategy();
                case AccessorStrategy.Properties:
                    return new PropertyAccessorStrategy();
                default:
                    throw ExceptionBecause.UnknownAccessorStrategy(mimicSettings.AccessorStrategy);
            }
        }
    }
}