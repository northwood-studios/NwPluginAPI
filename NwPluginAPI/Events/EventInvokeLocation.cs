using System;
using System.Reflection;

namespace PluginAPI.Events
{
	/// <summary>
	/// Represents a event handlers location.
	/// </summary>
	public class EventInvokeLocation
	{
		public Type Plugin;
		public object Target;
		public MethodInfo Method;

		public bool IsDefaultMethod;
	}
}