using System.Collections.Generic;
using System.Reflection;
using Mimic.Core.Services.Factories;
using Mimic.Core.Types.KnownProperties;
using Mimic.Core.UnitTests.Framework;
using NUnit.Framework;

namespace Mimic.Core.UnitTests.Services.Factories
{
    [TestFixture]
    public class GivenATypeWithKnownProperties
    {
        private List<IKnownProperty> _result;

        [SetUp]
        public void WhenExtractingTheKnownProperties()
        {
            var assembly = new TestAssembly(new[] { typeof(StringTestKnownProperty), typeof(IntTestKnownProperty) });
            
            var subject = new KnownPropertyFactory(new ObjectActivator());
            _result = subject.From(assembly);
        }
        
        [Test]
        public void ThenTheKnownPropertiesAreInstantiated()
        {
            Assert.That(_result[0], Is.TypeOf(typeof(StringTestKnownProperty)));
            Assert.That(_result[1], Is.TypeOf(typeof(IntTestKnownProperty)));
        }

        internal class IntTestKnownProperty : SimpleKnownProperty<int>
        {
            public override int Value(IValueFactory valueFactory)
            {
                return 8;
            }

            public override bool Matches(string propertyName)
            {
                return propertyName == "Int";
            }
        }

        public class StringTestKnownProperty : IKnownProperty
        {
            public bool Is(PropertyInfo propertyInfo)
            {
                return true;
            }

            public void SetOn(PropertyInfo propertyInfo, object returnObject, IValueFactory valueFactory)
            {
            }

            public object New()
            {
                return null;
            }
        }
    }
}