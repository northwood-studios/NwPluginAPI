	using PluginAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

		private readonly List<Type> ParametersToRegenerate = new List<Type>()
		{
			{ typeof(IPlayer) }
		};

		private readonly List<IndexInfo> IndexesToRegenerate = new List<IndexInfo>();

		public readonly Dictionary<Type, List<EventInvokeLocation>> Invokers = new Dictionary<Type, List<EventInvokeLocation>>();

		public readonly EventParameter[] Parameters;

		/// <summary>
		/// Initializes a new instance of the <see cref="Event"/> class.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		public Event(params EventParameter[] parameters)
		{
			Parameters = parameters;

			for (int x = 0; x < Parameters.Length; x++)
			{
				if (!ParametersToRegenerate.Contains(Parameters[x].BaseType)) continue;

				IndexesToRegenerate.Add(new IndexInfo() { Index = x, Type = Parameters[x].BaseType });
			}
		}

		public object[] RegenerateParameters(EventInvokeLocation invoker, object[] parameters)
		{
			object[] regeneratedParameters = parameters.ToArray();

			foreach (var index in IndexesToRegenerate)
			{
				if (parameters[index.Index] == null)
				{
					regeneratedParameters[index.Index] = null;
					continue;
				}

				if (index.Type == typeof(IPlayer))
					regeneratedParameters[index.Index] = EventManager.GetPlayerFactory(invoker).GetOrAdd((IGameComponent)parameters[index.Index]);
			}

			return regeneratedParameters;
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
