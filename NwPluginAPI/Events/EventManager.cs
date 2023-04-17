using Footprinting;
using PlayerRoles.PlayableScps.Scp079.Cameras;
using PlayerRoles.PlayableScps.Scp096;
using PlayerRoles.Voice;

namespace PluginAPI.Events
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using AdminToys;
	using CustomPlayerEffects;
	using InventorySystem.Items;
	using InventorySystem.Items.Firearms;
	using InventorySystem.Items.Radio;
	using InventorySystem.Items.Usables;
	using MapGeneration.Distributors;
	using PlayerRoles;
	using PlayerStatsSystem;
	using Core;
	using Core.Attributes;
	using Core.Factories;
	using Core.Interfaces;
	using Enums;
	using ItemPickupBase = InventorySystem.Items.Pickups.ItemPickupBase;
	using Respawning;
	using Loader;
	using InventorySystem.Items.ThrowableProjectiles;
	using PlayerRoles.PlayableScps.Scp173;
	using PlayerRoles.PlayableScps.Scp079;
	using MapGeneration;
	using Interactables.Interobjects.DoorUtils;
	using UnityEngine;
	using PlayerRoles.PlayableScps.Scp939;
	using CommandSystem;
	using LiteNetLib;
	using Scp914;
	using Interactables.Interobjects;
	using Mirror;
	using static UnityEngine.GraphicsBuffer;
	using System.Security.Cryptography;
	using System.Runtime.Serialization;

	/// <summary>
	/// Manages plugin events.
	/// </summary>
	public static class EventManager
	{
		/// <summary>
		/// Contains all registered event handlers.
		/// </summary>
		private static readonly Dictionary<Type, object> EventHandlers = new Dictionary<Type, object>();

		/// <summary>
		/// Contains all events and their parameters.
		/// </summary>
		public static readonly Dictionary<ServerEventType, Event> Events = new Dictionary<ServerEventType, Event>();

		/// <summary>
		/// Contains all event types and their event types.
		/// </summary>

		public static readonly Dictionary<Type, ServerEventType> TypeToEvent = new Dictionary<Type, ServerEventType>();

		internal static void Init()
		{
			foreach(var type in typeof(EventManager).Assembly.GetTypes())
			{
				var interfaces = type.GetInterfaces();
				try
				{
					if (interfaces.Length != 1) continue;

					if (interfaces[0] != typeof(IEventArguments)) continue;

					var evArg = (IEventArguments)Activator.CreateInstance(type, true);

					if (Events.ContainsKey(evArg.BaseType)) continue;

					Events.Add(evArg.BaseType, new Event(evArg));
					TypeToEvent.Add(type, evArg.BaseType);
				}
				catch(Exception ex)
				{
					Log.Error(ex.ToString());
				}

			}
		}

		private static bool ValidateEvent(Event ev, Type[] parameters, ref bool isDefaultMethod)
		{
			var requiredParameters = ev.Parameters.Select(x => x.BaseType).ToArray();

			if (parameters.Length == 1 && parameters[0] == ev.EventArgType)
			{
				isDefaultMethod = false;
				return true;
			}

			if (parameters.Length != requiredParameters.Length)
				return false;

			for (int x = 0; x < requiredParameters.Length; x++)
			{
				if (requiredParameters[x].IsInterface)
				{
					if (!requiredParameters[x].IsAssignableFrom(parameters[x]))
						return false;
				}
				else if (requiredParameters[x] != parameters[x])
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Registers all events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterAllEvents(object plugin)
		{
			Type pluginType = plugin.GetType();

			if (!AssemblyLoader.PluginToAssembly.TryGetValue(plugin, out Assembly assembly)) return;

			foreach (var type in assembly.GetTypes().Where(x => x.IsClass))
			{
				bool foundEvents = false;
				foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
				{
					foreach (var attribute in method.GetCustomAttributes<Attribute>())
					{
						switch (attribute)
						{
							case PluginEvent _:
								foundEvents = true;
								break;
						}
					}
				}

				if (foundEvents)
				{
					if (!EventHandlers.TryGetValue(type, out object handler))
					{
						handler = Activator.CreateInstance(type);
						EventHandlers.Add(type, handler);
					}

					RegisterEvents(plugin, handler);
				}
			}
		}

		/// <summary>
		/// Registers all events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void UnregisterAllEvents(object plugin)
		{
			Type pluginType = plugin.GetType();

			foreach (var handler in Events
				         .SelectMany(x =>
					         x.Value.Invokers.Where(y => y.Key == pluginType))
				         .SelectMany(x =>
					         x.Value.Select(y => y.Target))
				         .Distinct())
			{
				UnregisterEvents(pluginType, handler);
			}
		}

		/// <summary>
		/// Registers events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterEvents(object plugin)
		{
			Type type = plugin.GetType();
			RegisterEvents(type, plugin);
		}

		/// <summary>
		/// Unregisters events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void UnregisterEvents(object plugin)
		{
			Type type = plugin.GetType();
			UnregisterEvents(type, plugin);
		}

		/// <summary>
		/// Registers events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterEvents<T>(object plugin) where T : class
		{
			if (!EventHandlers.TryGetValue(typeof(T), out object handler))
			{
				handler = Activator.CreateInstance(typeof(T));
				EventHandlers.Add(typeof(T), handler);
			}

			RegisterEvents(plugin.GetType(), handler);
		}

		/// <summary>
		/// Unregisters events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void UnregisterEvents<T>(object plugin) where T : class
		{
			if (!EventHandlers.TryGetValue(typeof(T), out object handler)) return;

			UnregisterEvents(plugin.GetType(), handler);
		}

		/// <summary>
		/// Registers events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		public static void RegisterEvents(object plugin, object eventHandler) => RegisterEvents(plugin.GetType(), eventHandler);

		/// <summary>
		/// Unregisters events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		public static void UnregisterEvents(object plugin, object eventHandler) => UnregisterEvents(plugin.GetType(), eventHandler);


		/// <summary>
		/// Registers events in plugin.
		/// </summary>>
		/// <param name="plugin">Object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		static void RegisterEvents(Type plugin, object eventHandler)
		{
			foreach (var method in eventHandler.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				foreach (var attribute in method.GetCustomAttributes<Attribute>())
				{
					switch (attribute)
					{
						case PluginEvent pluginEvent:
							var eventParameters = method.GetParameters().Select(p => p.ParameterType).ToArray();

							var targetType = pluginEvent.EventType;

							if (eventParameters.Length != 0 && eventParameters[0] == typeof(IEventArguments))
							{
								TypeToEvent.TryGetValue(eventParameters[0], out targetType);
							}

							if (!Events.TryGetValue(targetType, out Event ev))
							{
								Log.Error($"Event &6{targetType}&r is not registered in manager! ( create issue on github )");
								continue;
							}

							bool isDefaultMethod = true;
							if (!ValidateEvent(ev, eventParameters, ref isDefaultMethod))
							{
								Log.Error($"Event &6{method.Name}&r (&6{targetType}&r) in plugin &6{plugin.FullName}&r contains wrong parameters\n - &6{(string.Join(", ", eventParameters.Select(p => p.Name)))}\n - Required:\n - &6{(string.Join(", ", ev.Parameters.Select(p => p.BaseType.Name)))}.");
								continue;
							}

							ev.RegisterInvoker(plugin, eventHandler, method, isDefaultMethod);

							Log.Debug($"Registered event &6{method.Name}&r (&6{targetType}&r) in plugin &6{plugin.FullName}&r!", Log.DebugMode);
							break;
					}
				}
			}
		}

		/// <summary>
		/// Unregisters events in plugin.
		/// </summary>>
		/// <param name="plugin">Object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		static void UnregisterEvents(Type plugin, object eventHandler)
		{
			foreach (var ev in Events)
			{
				foreach (var invoker in ev.Value.Invokers.ToArray())
				{
					foreach (var location in invoker.Value.ToArray())
					{
						if (location.Target != eventHandler) continue;

						invoker.Value.Remove(location);
						Log.Debug($"Unregistered event &6{location.Method.Name}&r (&6{ev.Key}&r) in plugin &6{plugin.FullName}&r!", Log.DebugMode);
					}
				}
			}
		}

		internal static PlayerFactory GetPlayerFactory(EventInvokeLocation ev)
		{
			if (!FactoryManager.PlayerFactories.TryGetValue(ev.Plugin, out PlayerFactory pFactory))
				pFactory = FactoryManager.PlayerFactories[typeof(EventManager)];

			return pFactory;
		}

		/// <summary>
		/// Executes event.
		/// </summary>
		/// <param name="type">The type of event</param>
		/// <param name="args">The arguments of event.</param>
		/// <returns>If false event is cancelled.</returns>
		public static bool ExecuteEvent(IEventArguments args) => ExecuteEvent<bool>(args);

		/// <summary>
		/// Executes event.
		/// </summary>
		/// <param name="type">The type of event</param>
		/// <param name="args">The arguments of event.</param>
		/// <returns>Event cancellation data.</returns>
		// ReSharper disable once MemberCanBePrivate.Global
		public static T ExecuteEvent<T>(IEventArguments args) where T : struct
		{
			if (!Events.TryGetValue(args.BaseType, out Event ev))
			{
				Log.Error($"Event &6{args.BaseType}&r is not registered in manager! ( create issue on github )");
				return default;
			}

			bool isBool = typeof(T) == typeof(bool);
			bool cancelled = false;

			T cancellation;

			if (isBool)
			{
				cancellation = (T)(object)true;
			}
			else cancellation = default;


			foreach (var plugin in ev.Invokers.Values)
			{
				foreach (var invoker in plugin)
				{
					object result;
					try
					{
						if (invoker.IsDefaultMethod)
						{
							var argType = args.GetType();

							object[] input = new object[0];

							Dictionary<EventParameter, int> evToIndex = new Dictionary<EventParameter, int>();

							int index = 0;
							foreach(var parameter in ev.Parameters)
							{
								input[input.Length] = parameter.PropertyInfo.GetValue(args);
								if (!parameter.IsReadonly)
									evToIndex.Add(parameter, index);
								index++;
							}

							result = invoker.Method.Invoke(invoker.Target, input);

							foreach (var parameter in evToIndex)
								parameter.Key.PropertyInfo.SetValue(args, input[parameter.Value]);
						}
						else
						{
							result = invoker.Method.Invoke(invoker.Target, new object[] { args });
						}
					}
					catch (Exception ex)
					{
						Log.Error($"Failed executing event &6{invoker.Method.Name}&r (&6{args.BaseType}&r) in plugin &6{invoker.Plugin.FullName}&r\n{ex}");
						continue;
					}

					if (cancelled || result is null)
						continue;

					if (isBool)
					{
						if (result is bool b && b)
							continue;

						cancellation = (T)result;
						cancelled = true;
					}
					else if (result is T r)
					{
						if (!(r is IEventCancellation ecd) || !ecd.IsCancelled)
							continue;

						cancellation = r;
						cancelled = true;
					}
					else
					{
						Log.Error($"Plugin &6{invoker.Plugin.FullName}&r passed invalid data type for event &6{invoker.Method.Name}&r.");
					}
				}
			}

			return cancellation;
		}
	}
}
