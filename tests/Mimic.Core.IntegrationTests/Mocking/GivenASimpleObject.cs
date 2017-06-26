using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Mocking
{
    [TestFixture]
    public class GivenASimpleObject
    {
        [Test]
        public void WhenMockingTheObjectByType()
        {
            var subject = new Mimic<SimpleObject>().CreateInstance();
            Assert.That(subject.Int, Is.Not.EqualTo(0));
            Assert.That(subject.String, Is.Not.Null);
            Assert.That(subject.Decimal, Is.Not.EqualTo(0));
        }
    }
}