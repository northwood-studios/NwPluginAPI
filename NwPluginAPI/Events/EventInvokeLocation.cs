using System;
using System.Collections.Generic;
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

		/// <summary>
		/// Invokes the handler.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <returns>The return value.</returns>
		public object Invoke(List<object> parameters) => Method.Invoke(Target, parameters.ToArray());
	}
}
