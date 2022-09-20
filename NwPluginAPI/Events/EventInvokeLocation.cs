using System;
using System.Collections.Generic;
using System.Reflection;

namespace PluginAPI.Events
{
	public class EventInvokeLocation
	{
		public Type Plugin;
		public object Target;
		public MethodInfo Method;

		public object Invoke(List<object> parameters) => Method.Invoke(Target, parameters.ToArray());
	}
}
