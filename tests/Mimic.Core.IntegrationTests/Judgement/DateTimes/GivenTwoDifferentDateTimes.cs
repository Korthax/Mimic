using System;
using Mimic.Core.Services;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.DateTimes
{
    [TestFixture]
    public class GivenTwoDifferentDateTimes
    {
        [Test]
        public void ThenTheObjectsDoNotMatch()
        {
            var subject = new Equality(new MimicSettings());
            Assert.That(subject.Judge(new DateTime(1991, 01, 24, 12, 35, 15, 1), DateTime.Now), Is.False);
        }
    }
}