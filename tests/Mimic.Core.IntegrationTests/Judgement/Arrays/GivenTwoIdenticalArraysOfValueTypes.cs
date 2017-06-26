using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Arrays
{
    [TestFixture]
    public class GivenTwoIdenticalArraysOfValueTypes
    {
        [Test]
        public void ThenTwoEqualArraysAreEqual()
        {
            var one = new[] { 0, 2, 3, 4 };
            var two = new[] { 0, 2, 3, 4 };
            var subject = new Equality(new MimicSettings());
            var result = subject.Judge(one, two);
            Assert.That(result, Is.True);
        }
    }
}