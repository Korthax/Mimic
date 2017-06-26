using Mimic.Core.Services.Factories;

namespace Mimic.Core.Types.KnownTypes
{
    public interface IJudgeableType : IKnownType
    {
        bool AreEqual<T>(T object1, T object2, IComparisonFactory comparisonFactory);
    }
}