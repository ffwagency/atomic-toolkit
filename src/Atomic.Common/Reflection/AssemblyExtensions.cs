using System.Reflection;
using Umbraco.Extensions;

namespace Atomic.Common.Reflection;

public static class AssemblyExtensions
{
	public static bool IsAtomicAssembly(this Assembly assembly)
	{
		return assembly.GetName().Name?.InvariantStartsWith(Constants.AtomicAssembliesPrefix) == true;
	}
}
