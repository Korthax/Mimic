using System.Reflection;
using Mimic.Core.Types.KnownProperties;
using Mimic.Core.UnitTests.Framework;
using NUnit.Framework;

namespace Mimic.Core.UnitTests.Types.KnownProperties
{
    [TestFixture]
    public class GivenATitle
    {
        [Test]
        public void WhenBuildingTheKnownPropertyThenThePropertyCanBeMatched()
        {
            var subject = new TitleKnownProperty();
            Assert.That(subject.Is(typeof(KnownPropertyTestObject).GetProperty("Title")));
        }
    }
}