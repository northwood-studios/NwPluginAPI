using System;
using System.Collections.Generic;
using System.Reflection;

namespace PluginAPI.Events
{
	public class Event
	{
		public readonly Dictionary<Type, List<EventInvokeLocation>> Invokers = new Dictionary<Type, List<EventInvokeLocation>>();

		public readonly EventParameter[] Parameters;

		public Event(params EventParameter[] parameters)
		{
			Parameters = parameters;
		}

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
