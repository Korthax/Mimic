using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Mocking
{
    [TestFixture]
    public class GivenASimpleObjectWithAMatchingKnownType
    {
        [Test]
        public void WhenMockingTheObject()
        {
            var subject = new Mimic<SimpleObject>()
                .Register(new SimpleObject { Decimal = 999.99m, Int = -88, String = "SimpleObjectString"} )
                .CreateInstance();

            Assert.That(subject.Int, Is.EqualTo(-88));
            Assert.That(subject.String, Is.EqualTo("SimpleObjectString"));
            Assert.That(subject.Decimal, Is.EqualTo(999.99m));
        }
    }
}