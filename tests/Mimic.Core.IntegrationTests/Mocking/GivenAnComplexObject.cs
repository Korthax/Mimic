using System;
using Mimic.Core.Services;
using Mimic.Core.Services.Tracing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Mocking
{
    [TestFixture]
    public class GivenAnComplexObject
    {
        [Test]
        public void WhenMockingTheObjectByType()
        {
            var subject = new Mimic<ComplexObject>(new MimicSettings { Tracer = new ConsoleTracer() })
                .Register(new SimpleObject { Decimal = 999.99m, Int = -88, String = "SimpleObjectString" })
                .Register("SimpleObject2", new SimpleObject { Decimal = 4m, Int = -4, String = "4" })
                .Register("SetMe", "Hello")
                .CreateInstance();

            Console.WriteLine(JsonConvert.SerializeObject(subject, Formatting.Indented));

            Assert.That(subject.SetMe, Is.EqualTo("Hello"));

            Assert.That(subject.SimpleObject.Int, Is.EqualTo(-88));
            Assert.That(subject.SimpleObject.String, Is.EqualTo("SimpleObjectString"));
            Assert.That(subject.SimpleObject.Decimal, Is.EqualTo(999.99m));

            Assert.That(subject.SimpleObject2.Int, Is.EqualTo(-4));
            Assert.That(subject.SimpleObject2.String, Is.EqualTo("4"));
            Assert.That(subject.SimpleObject2.Decimal, Is.EqualTo(4m));

            Assert.That(subject.SimpleObject3.Int, Is.EqualTo(-88));
            Assert.That(subject.SimpleObject3.String, Is.EqualTo("SimpleObjectString"));
            Assert.That(subject.SimpleObject3.Decimal, Is.EqualTo(999.99m));
        }
    }
}