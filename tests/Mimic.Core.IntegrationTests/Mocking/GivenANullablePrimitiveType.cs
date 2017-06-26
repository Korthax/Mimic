using System.Collections.Generic;
using System.Linq;
using Mimic.Core.Services;
using Mimic.Core.Services.Tracing;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Mocking
{
    [TestFixture(typeof(int?))]
    [TestFixture(typeof(char?))]
    [TestFixture(typeof(int?))]
    [TestFixture(typeof(decimal?))]
    [TestFixture(typeof(double?))]
    [TestFixture(typeof(float?))]
    [TestFixture(typeof(short?))]
    [TestFixture(typeof(byte?))]
    [TestFixture(typeof(bool?))]
    [TestFixture(typeof(long?))]
    [TestFixture(typeof(uint?))]
    [TestFixture(typeof(ulong?))]
    [TestFixture(typeof(ushort?))]
    public class GivenANullablePrimitiveType<T> : ITracer
    {
        private List<string> _messages;
        private object _result;

        [SetUp]
        public void WhenMockingTheObject()
        {
            _messages = new List<string>();
            _result = new Mimic<T>(new MimicSettings { Tracer = this }).CreateInstance();
        }

        [Test]
        public void ThenTheKnownTypeIsFound()
        {
            Assert.That(_messages.Any(x => x.StartsWith("[Construct] <Known Type> '" + typeof(T).FullName)));
        }

        [Test]
        public void ThenTheKnownTypeIsInstantiated()
        {
            Assert.That(_result, Is.Not.Null);
        }

        public void Log(string message)
        {
            _messages.Add(message);
        }
    }
}