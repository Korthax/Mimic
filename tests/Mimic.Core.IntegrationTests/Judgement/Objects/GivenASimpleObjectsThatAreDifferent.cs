using System;
using Mimic.Core.IntegrationTests.Mocking;
using Mimic.Core.Services;
using Mimic.Core.Services.Tracing;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Objects
{
    [TestFixture]
    public class GivenASimpleObjectsThatAreDifferent : ITracer
    {
        [TestCase(12d, 55, "hello")]
        [TestCase(12d, 255, "test")]
        [TestCase(88d, 55, "test")]
        public void ThenTheObjectsAreJudgedNotEqual(decimal @decimal, int integer, string @string)
        {
            var one = new SimpleObject { Decimal = 12, Int = 55, String = "test" };
            var two = new SimpleObject { Decimal = @decimal, Int = integer, String = @string };
            var subject = new Equality(new MimicSettings { Tracer = this });
            var result = subject.Judge(one, two);
            Assert.That(result, Is.False);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}