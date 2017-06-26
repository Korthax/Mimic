using System;
using Mimic.Core.Types.Simple;

namespace Mimic.Core.UnitTests.Framework
{
    public class TestAssembly : IAssembly
    {
        private readonly Type[] _types;

        public TestAssembly(Type[] types)
        {
            _types = types;
        }

        public Type[] GetTypes()
        {
            return _types;
        }
    }
}