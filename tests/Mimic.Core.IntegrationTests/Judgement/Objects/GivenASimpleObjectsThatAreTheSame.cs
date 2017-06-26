using System;
using Mimic.Core.IntegrationTests.Mocking;
using Mimic.Core.Services;
using Mimic.Core.Services.Tracing;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Objects
{
    [TestFixture]
    public class GivenASimpleObjectsThatAreTheSame : ITracer
    {
        [Test]
        public void ThenTheObjectsAreJudgedEqual()
        {
            var one = new SimpleObject { Decimal = 12, Int = 55, String = "test" };
            var two = new SimpleObject { Decimal = 12, Int = 55, String = "test" };
            var subject = new Equality(new MimicSettings { Tracer = this });
            var result = subject.Judge(one, two);
            Assert.That(result, Is.True);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}