using System;
using System.Collections.Generic;
using System.Linq;
using Mimic.Core.Services;
using Mimic.Core.Services.Tracing;
using NUnit.Framework;

namespace Mimic.Core.IntegrationTests.Mocking
{
    [TestFixture(typeof(String))]
    [TestFixture(typeof(Char))]
    [TestFixture(typeof(Int32))]
    [TestFixture(typeof(Decimal))]
    [TestFixture(typeof(Double))]
    [TestFixture(typeof(DateTime))]
    [TestFixture(typeof(Int16))]
    [TestFixture(typeof(Byte))]
    [TestFixture(typeof(Boolean))]
    [TestFixture(typeof(Single))]
    [TestFixture(typeof(Int64))]
    [TestFixture(typeof(UInt32))]
    [TestFixture(typeof(UInt64))]
    [TestFixture(typeof(UInt16))]
    public class GivenASystemType<T> : ITracer
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