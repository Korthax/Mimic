using System;
using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.DateTimes
{
    [TestFixture]
    public class GivenTheSameDateTime
    {
        [Test]
        public void ThenTheObjectsAreEqual()
        {
            var dateTime = new DateTime(1991, 01, 24, 12, 35, 15, 1);
            var subject = new Equality(new MimicSettings());
            Assert.That(subject.Judge(dateTime, dateTime), Is.True);
        }
    }
}