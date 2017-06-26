using System;
using System.Collections.Generic;
using Mimic.Core.IntegrationTests.Mocking;
using Mimic.Core.Services;
using Mimic.Core.Services.Tracing;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Judgement.Objects
{
    [TestFixture]
    public class GivenTwoEqualAComplexObject : ITracer
    {
        [Test]
        public void WhenCheckingTheEqualityThenTheObjectMatches()
        {
            var one = new ComplexObject
            {
                Uri = new Uri("http://www.google.co.uk/test?q=test"),
                DateTime = new DateTime(2015, 01, 24, 12, 35, 15, 21),
                SimpleObjects = new List<SimpleObject>
                {
                    new SimpleObject { Decimal = 12, Int = 55, String = "test" },
                    new SimpleObject { Decimal = 12, Int = 55, String = "test" }
                },
                SimpleDictionaries = new Dictionary<string, int>
                {
                    { "one", 1 },
                    { "two", 2 },
                    { "three", 3 },
                }
            };

            var two = new ComplexObject
            {
                Uri = new Uri("http://www.google.co.uk/test?q=test"),
                DateTime = new DateTime(2015, 01, 24, 12, 35, 15, 21),
                SimpleObjects = new List<SimpleObject>
                {
                    new SimpleObject { Decimal = 12, Int = 55, String = "test" },
                    new SimpleObject { Decimal = 12, Int = 55, String = "test" }
                },
                SimpleDictionaries = new Dictionary<string, int>
                {
                    { "one", 1 },
                    { "two", 2 },
                    { "three", 3 },
                }
            };

            var subject = new Equality(new MimicSettings { Tracer = this });
            Assert.That(subject.Judge(one, two), Is.True);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public class ComplexObject
        {
            public DateTime DateTime { get; set; }
            public Uri Uri { get; set; }
            public List<SimpleObject> SimpleObjects { get; set; }
            public Dictionary<string, int> SimpleDictionaries { get; set; }
        }
    }
}