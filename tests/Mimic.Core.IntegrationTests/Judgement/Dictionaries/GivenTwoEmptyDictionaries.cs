using System.Collections.Generic;
using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Dictionaries
{
    [TestFixture]
    public class GivenTwoEmptyDictionaries
    {
        [Test]
        public void ThenTheObjectsAreEqual()
        {
            var one = new Dictionary<string, int>();
            var two = new Dictionary<string, int>();
            var subject = new Equality(new MimicSettings());
            Assert.That(subject.Judge(one, two), Is.True);
        }
    }
}