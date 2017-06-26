using System;
using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Uris
{
    [TestFixture]
    public class GivenTwoIdenticalUris
    {
        [Test]
        public void ThenTheObjectsAreEqual()
        {
            var subject = new Equality(new MimicSettings());
            Assert.That(subject.Judge(new Uri("http://www.google.com"), new Uri("http://www.google.com")), Is.True);
        }
    }
}