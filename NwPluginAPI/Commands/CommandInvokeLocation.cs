using System.Reflection;

namespace PluginAPI.Commands
{
	public class CommandInvokeLocation
	{
		public object Target;
		public MethodInfo Method;
	}
}
