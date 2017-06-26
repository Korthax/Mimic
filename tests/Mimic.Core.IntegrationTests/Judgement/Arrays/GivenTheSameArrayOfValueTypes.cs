using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Arrays
{
    [TestFixture]
    public class GivenTheSameArrayOfValueTypes
    {
        [Test]
        public void ThenTheSameInstanceIsEqual()
        {
            var one = new[] { 0, 2, 3, 4 };
            var subject = new Equality(new MimicSettings());
            var result = subject.Judge(one, one);
            Assert.That(result, Is.True);
        }
    }
}