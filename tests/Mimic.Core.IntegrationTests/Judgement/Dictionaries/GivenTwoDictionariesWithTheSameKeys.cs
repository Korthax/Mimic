using System.Collections.Generic;
using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Dictionaries
{
    [TestFixture]
    public class GivenTwoDictionariesWithTheSameKeys
    {
        [Test]
        public void ThenTheObjectsAreEqual()
        {
            var one = new Dictionary<string, int> { { "one", 1 }, { "two", 2 } };
            var two = new Dictionary<string, int> { { "two", 2 }, { "one", 1 } };
            var subject = new Equality(new MimicSettings());
            Assert.That(subject.Judge(one, two), Is.True);
        }
    }
}