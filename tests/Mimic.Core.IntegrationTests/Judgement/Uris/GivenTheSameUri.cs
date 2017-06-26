using System;
using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Uris
{
    [TestFixture]
    public class GivenTheSameUri
    {
        [Test]
        public void ThenTheObjectsAreEqual()
        {
            var uri = new Uri("http://www.google.com");
            var subject = new Equality(new MimicSettings());
            Assert.That(subject.Judge(uri, uri), Is.True);
        }
    }
}