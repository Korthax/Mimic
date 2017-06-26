using System.Collections.Generic;
using Mimic.Core.Services;
using Mimic.Core.Services.Factories;
using Mimic.Core.Types.KnownTypes;
using Mimic.Core.UnitTests.Framework;
using NUnit.Framework;

namespace Mimic.Core.UnitTests.Services.Factories
{
    [TestFixture]
    public class GivenAnAssemblyWithABasicKnownType
    {
        private List<IImitableType> _result;

        [SetUp]
        public void WhenExtractingTheKnownTypes()
        {
            var assembly = new TestAssembly(new[] { typeof (SimpleObjectKnownType), typeof(string) });
            var subject = new ImitableTypeFactory(new ObjectActivator());
            _result = subject.From(assembly, new MimicSettings());
        }
        
        [Test]
        public void ThenTheKnownTypesAreInstantiated()
        {
            Assert.That(_result[0], Is.TypeOf(typeof(SimpleObjectKnownType)));
        }
    }
}