using System;
using System.Reflection;

namespace Mimic.Core.Types.Simple
{
    public interface IAssembly
    {
        Type[] GetTypes();
    }

    public sealed class AssemblyAdapter : IAssembly
    {
        private readonly Assembly _assembly;

        public AssemblyAdapter(Assembly assembly)
        {
            _assembly = assembly;
        }

        public Type[] GetTypes()
        {
            return _assembly.GetTypes();
        }
    }
}