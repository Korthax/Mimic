using System.Reflection;
using Mimic.Core.Types.KnownProperties;
using Mimic.Core.UnitTests.Framework;
using NUnit.Framework;

namespace Mimic.Core.UnitTests.Types.KnownProperties
{
    [TestFixture]
    public class GivenAPostCode
    {
        [Test]
        public void WhenBuildingTheKnownPropertyThenThePropertyCanBeMatched()
        {
            var subject = new PostCodeKnownProperty();
            Assert.That(subject.Is(typeof(KnownPropertyTestObject).GetProperty("PostCode")));
        }
    }
}