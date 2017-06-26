using System;
using Mimic.Core.IntegrationTests.Mocking;
using Mimic.Core.Services;
using Mimic.Core.Services.Tracing;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Objects
{
    [TestFixture]
    public class GivenTheSameSimpleObject : ITracer
    {
        [Test]
        public void ThenTheObjectsAreJudgedEqual()
        {
            var one = new SimpleObject { Decimal = 12, Int = 55, String = "test" };
            var subject = new Equality(new MimicSettings { Tracer = this });
            var result = subject.Judge(one, one);
            Assert.That(result, Is.True);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}