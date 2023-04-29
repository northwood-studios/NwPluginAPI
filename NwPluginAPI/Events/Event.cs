using PluginAPI.Core.Attributes;
using PluginAPI.Core.Interfaces;
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
		private class IndexInfo
		{
			public int Index;
			public Type Type;
		}

		private readonly List<Type> ParametersToRegenerate = new()
		{
			{ typeof(IPlayer) }
		};

		public readonly Dictionary<Type, List<EventInvokeLocation>> Invokers = new();

		public readonly List<EventParameter> Parameters = new List<EventParameter>();

		public readonly IEventArguments EventArg;
		public readonly Type EventArgType;

		/// <summary>
		/// Initializes a new instance of the <see cref="Event"/> class.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		public Event(IEventArguments args)
		{
			EventArg = args;
			EventArgType = EventArg.GetType();

			foreach(var property in EventArgType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				var argument = property.GetCustomAttribute<EventArgument>();

				if (argument == null) continue;

				Parameters.Add(new EventParameter(property.PropertyType.IsByRef ? property.PropertyType.GetElementType() : property.PropertyType, property, property.Name));
			}
		}

		/// <summary>
		/// Registers a event handler.
		/// </summary>
		/// <param name="plugin">The plugin of the handler.</param>
		/// <param name="handle">The handle.</param>
		/// <param name="method">The method.</param>
		/// <param name="defaultMethod">The default method.</param>
		public void RegisterInvoker(Type plugin, object handle, MethodInfo method, bool defaultMethod)
		{
			if (!Invokers.ContainsKey(plugin))
				Invokers.Add(plugin, new List<EventInvokeLocation>());

			Invokers[plugin].Add(new EventInvokeLocation()
			{
				Plugin = plugin,
				Target = handle,
				Method = method,
				IsDefaultMethod = defaultMethod
			});
		}
	}
}