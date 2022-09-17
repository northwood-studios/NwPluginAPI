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

	public static class EventManager
	{
		private class EventInfo
		{
			public Type Plugin;
			public object Target;
			public MethodInfo Method;
		}

		private class IndexInfo
		{
			public int Index;
			public Type Type;
		}

		private static readonly Dictionary<Type, List<Type>> EventHandlers = new Dictionary<Type, List<Type>>();

		private static readonly Dictionary<Type, object> HandlerInstances = new Dictionary<Type, object>();

		private static readonly Dictionary<ServerEventType, List<EventInfo>> RegisteredEvents = new Dictionary<ServerEventType, List<EventInfo>>();

		private static readonly Dictionary<ServerEventType, Type[]> RequiredParameters = new Dictionary<ServerEventType, Type[]>()
		{
			{ ServerEventType.PlayerJoined, new[] { typeof(IPlayer) } },
			{ ServerEventType.PlayerLeft, new[] { typeof(IPlayer) } },
			{ ServerEventType.PlayerDeath, new[] { typeof(IPlayer), typeof(IPlayer), typeof(DamageHandlerBase) } },
			{ ServerEventType.LczDecontaminationStart, Type.EmptyTypes },
			{ ServerEventType.LczDecontaminationAnnouncement, new[] { typeof(int) } },
			{ ServerEventType.MapGenerated, Type.EmptyTypes },
			{ ServerEventType.GrenadeExploded, new[] { typeof(ItemPickupBase) } },
			{ ServerEventType.ItemSpawned, new[] { typeof(ItemType) } },
			{ ServerEventType.GeneratorActivated, new[] { typeof(Scp079Generator) } },
			{ ServerEventType.PlaceBlood, Type.EmptyTypes },
			{ ServerEventType.PlaceBulletHole, Type.EmptyTypes },
			{ ServerEventType.PlayerActivateGenerator, new[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ ServerEventType.PlayerAimWeapon, new[] { typeof(IPlayer), typeof(Firearm), typeof(bool) } },
			{ ServerEventType.PlayerBanned, new[] { typeof(IPlayer), typeof(IPlayer), typeof(string), typeof(long) } },
			{ ServerEventType.PlayerCancelUsingItem, new[] { typeof(IPlayer), typeof(UsableItem) } },
			{ ServerEventType.PlayerChangeItem, new[] { typeof(IPlayer), typeof(ushort), typeof(ushort) } },
			{ ServerEventType.PlayerChangeRadioRange, new[] { typeof(IPlayer), typeof(RadioItem), typeof(byte) } },
			{ ServerEventType.PlayerChangeSpectator, new[] { typeof(IPlayer), typeof(IPlayer), typeof(IPlayer) } },
			{ ServerEventType.PlayerCloseGenerator, new[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ ServerEventType.PlayerDamagedShootingTarget, new[] { typeof(IPlayer), typeof(ShootingTarget), typeof(DamageHandlerBase), typeof(float) } },
			{ ServerEventType.PlayerDamagedWindow, new[] { typeof(IPlayer), typeof(BreakableWindow), typeof(DamageHandlerBase), typeof(float) } },
			{ ServerEventType.PlayerDeactivatedGenerator, new[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ ServerEventType.PlayerDropAmmo, new[] { typeof(IPlayer), typeof(ItemType), typeof(int) } },
			{ ServerEventType.PlayerDropItem, new[] { typeof(IPlayer), typeof(ItemBase) } },
			{ ServerEventType.PlayerDryfireWeapon, new[] { typeof(IPlayer), typeof(Firearm) } },
			{ ServerEventType.PlayerEscape, new[] { typeof(IPlayer), typeof(RoleTypeId) } },
			{ ServerEventType.PlayerHandcuff, new[] { typeof(IPlayer), typeof(IPlayer) } },
			{ ServerEventType.PlayerRemoveHandcuffs, new[] { typeof(IPlayer), typeof(IPlayer) } },
			{ ServerEventType.PlayerDamage, new[] { typeof(IPlayer), typeof(IPlayer), typeof(DamageHandlerBase) } },
			{ ServerEventType.PlayerInteractElevator, new[] { typeof(IPlayer) } },
			{ ServerEventType.PlayerInteractLocker, new[] { typeof(IPlayer) } },
			{ ServerEventType.PlayerInteractScp330, new[] { typeof(IPlayer) } },
			{ ServerEventType.PlayerInteractShootingTarget, new[] { typeof(IPlayer) } },
			{ ServerEventType.PlayerKicked, new[] { typeof(IPlayer), typeof(IPlayer), typeof(string) } },
			{ ServerEventType.PlayerMakeNoise, new[] { typeof(IPlayer) } },
			{ ServerEventType.PlayerOpenGenerator, new[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ ServerEventType.PlayerPickupAmmo, new[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ ServerEventType.PlayerPickupArmor, new[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ ServerEventType.PlayerPickupScp330, new[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ ServerEventType.PlayerPreauth, new[] { typeof(string), typeof(string), typeof(long), typeof(CentralAuthPreauthFlags), typeof(string), typeof(byte[]) } },
			{ ServerEventType.PlayerReceiveEffect, new[] { typeof(IPlayer), typeof(PlayerEffect) } },
			{ ServerEventType.PlayerReloadWeapon, new[] { typeof(IPlayer), typeof(Firearm) } },
			{ ServerEventType.PlayerChangeRole, new[] { typeof(IPlayer), typeof(PlayerRoleBase), typeof(PlayerRoleBase), typeof(RoleChangeReason) } },
			{ ServerEventType.PlayerSearchPickup, new[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ ServerEventType.PlayerSearchedPickup, new[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ ServerEventType.PlayerShotWeapon, new[] { typeof(IPlayer), typeof(Firearm) } },
			{ ServerEventType.PlayerSpawn, new[] { typeof(IPlayer), typeof(RoleTypeId) } },
			{ ServerEventType.RagdollSpawn, new[] { typeof(IPlayer), typeof(IRagdollRole), typeof(DamageHandlerBase) } },
			{ ServerEventType.PlayerThrowItem, new[] { typeof(IPlayer), typeof(ItemBase) } },
			{ ServerEventType.PlayerToggleFlashlight, new[] { typeof(IPlayer), typeof(ItemBase), typeof(bool) } },
			{ ServerEventType.PlayerUnloadWeapon, new[] { typeof(IPlayer), typeof(Firearm) } },
			{ ServerEventType.PlayerUnlockGenerator, new[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ ServerEventType.PlayerUsedItem, new[] { typeof(IPlayer), typeof(ItemBase) } },
			{ ServerEventType.PlayerUseHotkey, new[] { typeof(IPlayer), typeof(ActionName) } },
			{ ServerEventType.PlayerUseItem, new[] { typeof(IPlayer), typeof(UsableItem) } },
			{ ServerEventType.PlayerReport, new[] { typeof(IPlayer), typeof(IPlayer), typeof(string) } },
			{ ServerEventType.PlayerCheaterReport, new[] { typeof(IPlayer), typeof(IPlayer), typeof(string) } },
            { ServerEventType.RoundEnd, Type.EmptyTypes },
            { ServerEventType.RoundRestart, Type.EmptyTypes },
			{ ServerEventType.RoundStart, Type.EmptyTypes },
            { ServerEventType.WaitingForPlayers, Type.EmptyTypes },
        };

		private static bool ValidateEvent(Type[] parameters, Type[] requiredParameters)
		{
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
		/// Registers events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterEvents(object plugin)
		{
			Type type = plugin.GetType();
			RegisterEvents(type, type);
		}

		/// <summary>
		/// Registers events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterEvents<T>(object plugin) where T : Type => RegisterEvents(plugin.GetType(), typeof(T));

		/// <summary>
		/// Registers events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
        static void RegisterEvents(Type plugin, Type eventHandler)
		{
			if (!EventHandlers.ContainsKey(plugin))
				EventHandlers.Add(plugin, new List<Type>());

			if (!EventHandlers[plugin].Contains(eventHandler))
				EventHandlers[plugin].Add(eventHandler);

            if (!HandlerInstances.TryGetValue(eventHandler, out object handle))
			{
				handle = Activator.CreateInstance(eventHandler);
				HandlerInstances.Add(eventHandler, handle);
            }

            foreach (var method in eventHandler.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
                var attribute = method.GetCustomAttribute<Attribute>();

                switch (attribute)
				{
					case PluginEvent pluginEvent:

                        var eventParameters = method.GetParameters().Select(p => p.ParameterType).ToArray();

						if (!ValidateEvent(eventParameters, RequiredParameters[pluginEvent.EventType]))
						{
                            Log.Error($"Event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r contains wrong parameters\n - &6{(string.Join(", ", eventParameters.Select(p => p.Name)))}\n - Required:\n - &6{(string.Join(", ", RequiredParameters[pluginEvent.EventType].Select(p => p.Name)))}.");
                            continue;
						}

                        if (!RegisteredEvents.ContainsKey(pluginEvent.EventType))
							RegisteredEvents.Add(pluginEvent.EventType, new List<EventInfo>());

                        RegisteredEvents[pluginEvent.EventType].Add(new EventInfo()
                        {
	                        Plugin = plugin,
	                        Target = handle,
	                        Method = method,
                        });

                        Log.Info($"Registered event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r!");
                        break;
				}
			}
        }

		private static PlayerFactory GetPlayerFactory(EventInfo ev)
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
		/// <returns>If false event is canceled.</returns>
        public static bool ExecuteEvent(ServerEventType type, params object[] args)
		{
			if (!RegisteredEvents.TryGetValue(type, out var registeredEvents))
                return true;

            var constructEventParameters = new List<object>();
			var indexesToRegenerate = new List<IndexInfo>();
			
			for (int x = 0; x < RequiredParameters[type].Length; x++)
			{
				var paramType = RequiredParameters[type][x];

                if (args[x] == null)
				{
                    constructEventParameters.Add(null);
					continue;
                }

                if (paramType == typeof(IPlayer))
				{
					indexesToRegenerate.Add(new IndexInfo { Index = x, Type = paramType });
					constructEventParameters.Add(null);
                }
				else
					constructEventParameters.Add(args[x]);
            }

			var isCanceled = false;

			foreach (var ev in registeredEvents)
			{
				foreach (var index in indexesToRegenerate)
				{
					if (index.Type == typeof(IPlayer))
					{
						constructEventParameters[index.Index] = GetPlayerFactory(ev).GetOrAdd((IGameComponent)args[index.Index]);
					}
				}

                object result;
				try
				{
					result = ev.Method.Invoke(ev.Target, constructEventParameters.ToArray());
				}
				catch(Exception ex)
				{
					Log.Error($"Failed executing event &6{ev.Method.Name}&r (&6{type}&r) in plugin &6{ev.Plugin.FullName}&r\n{ex}");
					return true;
				}

				switch (result)
				{
					case bool b when !b:
						isCanceled = true;
                        break;
				}
			}

			return !isCanceled;
		}
    }
}
