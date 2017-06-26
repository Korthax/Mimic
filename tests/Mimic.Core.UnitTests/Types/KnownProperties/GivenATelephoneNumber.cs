using System.Reflection;
using Mimic.Core.Types.KnownProperties;
using Mimic.Core.UnitTests.Framework;
using NUnit.Framework;

namespace Mimic.Core.UnitTests.Types.KnownProperties
{
    [TestFixture]
    public class GivenATelephoneNumber
    {
        [Test]
        public void WhenBuildingTheKnownPropertyThenThePropertyCanBeMatched()
        {
            var subject = new TelephoneNumberKnownProperty();
            Assert.That(subject.Is(typeof(KnownPropertyTestObject).GetProperty("TelephoneNumber")));
        }
    }
}