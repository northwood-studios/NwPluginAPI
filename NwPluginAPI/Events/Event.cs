using System;
using System.Collections.Generic;
using System.Reflection;

namespace PluginAPI.Events
{
	/// <summary>
	/// Represents an event.
	/// </summary>
	public class Event
	{
		public readonly Dictionary<Type, List<EventInvokeLocation>> Invokers = new Dictionary<Type, List<EventInvokeLocation>>();

		public readonly EventParameter[] Parameters;

		/// <summary>
		/// Initializes a new instance of the <see cref="Event"/> class.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		public Event(params EventParameter[] parameters)
		{
			Parameters = parameters;
		}

		/// <summary>
		/// Registers a event handler.
		/// </summary>
		/// <param name="plugin">The plugin of the handler.</param>
		/// <param name="handle">The handle.</param>
		/// <param name="method">The method.</param>
		public void RegisterInvoker(Type plugin, object handle, MethodInfo method)
		{
			if (!Invokers.ContainsKey(plugin))
				Invokers.Add(plugin, new List<EventInvokeLocation>());

			Invokers[plugin].Add(new EventInvokeLocation()
			{
				Plugin = plugin,
				Target = handle,
				Method = method
			});
		}
	}
}
