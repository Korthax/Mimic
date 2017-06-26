using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Arrays
{
    [TestFixture]
    public class GivenTwoArraysOfValueTypesWhichAreDifferentLengths
    {
        [Test]
        public void ThenTwoEqualArraysAreNotEqual()
        {
            var one = new[] { 0, 2, 3 };
            var two = new[] { 0, 2, 3, 4 };
            var subject = new Equality(new MimicSettings());
            var result = subject.Judge(one, two);
            Assert.That(result, Is.False);
        }
    }
}