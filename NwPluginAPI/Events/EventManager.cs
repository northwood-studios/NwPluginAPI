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
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Core.Factories;
	using PluginAPI.Core.Interfaces;
	using PluginAPI.Enums;
	using ItemPickupBase = InventorySystem.Items.Pickups.ItemPickupBase;

	public static class EventManager
	{
		class EventInfo
		{
			public Type Plugin;
			public object Target;
			public MethodInfo Method;
		}

		class IndexInfo
		{
			public int Index;
			public Type Type;
		}

		private static Dictionary<Type, List<Type>> _eventHandlers = new Dictionary<Type, List<Type>>();

		private static Dictionary<Type, object> _handlerInstances = new Dictionary<Type, object>();

		private static Dictionary<int, List<EventInfo>> _registeredEvents = new Dictionary<int, List<EventInfo>>();

		private static Dictionary<int, Type[]> _requiredParameters = new Dictionary<int, Type[]>()
		{
			{ (int)ServerEventType.PlayerJoined, new Type[] { typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerLeft, new Type[] { typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerDeath, new Type[] { typeof(IPlayer), typeof(IPlayer), typeof(DamageHandlerBase) } },
			{ (int)ServerEventType.LczDecontaminationStart, new Type[0] },
			{ (int)ServerEventType.LczDecontaminationAnnouncement, new Type[] { typeof(int) } },
			{ (int)ServerEventType.MapGenerated, new Type[0] },
			{ (int)ServerEventType.GrenadeExploded, new Type[] { typeof(ItemPickupBase) } },
			{ (int)ServerEventType.ItemSpawned, new Type[] { typeof(ItemType) } },
			{ (int)ServerEventType.GeneratorActivated, new Type[] { typeof(Scp079Generator) } },
			{ (int)ServerEventType.PlaceBlood, new Type[0] },
			{ (int)ServerEventType.PlaceBulletHole, new Type[0] },
			{ (int)ServerEventType.PlayerActivateGenerator, new Type[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ (int)ServerEventType.PlayerAimWeapon, new Type[] { typeof(IPlayer), typeof(Firearm), typeof(bool) } },
			{ (int)ServerEventType.PlayerBanned, new Type[] { typeof(IPlayer), typeof(IPlayer), typeof(string), typeof(long) } },
			{ (int)ServerEventType.PlayerCancelUsingItem, new Type[] { typeof(IPlayer), typeof(UsableItem) } },
			{ (int)ServerEventType.PlayerChangeItem, new Type[] { typeof(IPlayer), typeof(ushort), typeof(ushort) } },
			{ (int)ServerEventType.PlayerChangeRadioRange, new Type[] { typeof(IPlayer), typeof(RadioItem), typeof(byte) } },
			{ (int)ServerEventType.PlayerChangeSpectator, new Type[] { typeof(IPlayer), typeof(IPlayer), typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerCloseGenerator, new Type[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ (int)ServerEventType.PlayerDamagedShootingTarget, new Type[] { typeof(IPlayer), typeof(ShootingTarget), typeof(DamageHandlerBase), typeof(float) } },
			{ (int)ServerEventType.PlayerDamagedWindow, new Type[] { typeof(IPlayer), typeof(BreakableWindow), typeof(DamageHandlerBase), typeof(float) } },
			{ (int)ServerEventType.PlayerDeactivatedGenerator, new Type[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ (int)ServerEventType.PlayerDropAmmo, new Type[] { typeof(IPlayer), typeof(ItemType), typeof(int) } },
			{ (int)ServerEventType.PlayerDropItem, new Type[] { typeof(IPlayer), typeof(ItemBase) } },
			{ (int)ServerEventType.PlayerDryfireWeapon, new Type[] { typeof(IPlayer), typeof(Firearm) } },
			{ (int)ServerEventType.PlayerEscape, new Type[] { typeof(IPlayer), typeof(RoleTypeId) } },
			{ (int)ServerEventType.PlayerHandcuff, new Type[] { typeof(IPlayer), typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerRemoveHandcuffs, new Type[] { typeof(IPlayer), typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerDamage, new Type[] { typeof(IPlayer), typeof(IPlayer), typeof(DamageHandlerBase) } },
			{ (int)ServerEventType.PlayerInteractElevator, new Type[] { typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerInteractLocker, new Type[] { typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerInteractScp330, new Type[] { typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerInteractShootingTarget, new Type[] { typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerKicked, new Type[] { typeof(IPlayer), typeof(IPlayer), typeof(string) } },
			{ (int)ServerEventType.PlayerMakeNoise, new Type[] { typeof(IPlayer) } },
			{ (int)ServerEventType.PlayerOpenGenerator, new Type[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ (int)ServerEventType.PlayerPickupAmmo, new Type[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ (int)ServerEventType.PlayerPickupArmor, new Type[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ (int)ServerEventType.PlayerPickupScp330, new Type[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ (int)ServerEventType.PlayerPreauth, new Type[] { typeof(string), typeof(string), typeof(long), typeof(CentralAuthPreauthFlags), typeof(string), typeof(byte[]) } },
			{ (int)ServerEventType.PlayerReceiveEffect, new Type[] { typeof(IPlayer), typeof(PlayerEffect) } },
			{ (int)ServerEventType.PlayerReloadWeapon, new Type[] { typeof(IPlayer), typeof(Firearm) } },
			{ (int)ServerEventType.PlayerChangeRole, new Type[] { typeof(IPlayer), typeof(PlayerRoleBase), typeof(PlayerRoleBase), typeof(RoleChangeReason) } },
			{ (int)ServerEventType.PlayerSearchPickup, new Type[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ (int)ServerEventType.PlayerSearchedPickup, new Type[] { typeof(IPlayer), typeof(ItemPickupBase) } },
			{ (int)ServerEventType.PlayerShotWeapon, new Type[] { typeof(IPlayer), typeof(Firearm) } },
			{ (int)ServerEventType.PlayerSpawn, new Type[] { typeof(IPlayer), typeof(RoleTypeId) } },
			{ (int)ServerEventType.RagdollSpawn, new Type[] { typeof(IPlayer), typeof(IRagdollRole), typeof(DamageHandlerBase) } },
			{ (int)ServerEventType.PlayerThrowItem, new Type[] { typeof(IPlayer), typeof(ItemBase) } },
			{ (int)ServerEventType.PlayerToggleFlashlight, new Type[] { typeof(IPlayer), typeof(ItemBase), typeof(bool) } },
			{ (int)ServerEventType.PlayerUnloadWeapon, new Type[] { typeof(IPlayer), typeof(Firearm) } },
			{ (int)ServerEventType.PlayerUnlockGenerator, new Type[] { typeof(IPlayer), typeof(Scp079Generator) } },
			{ (int)ServerEventType.PlayerUsedItem, new Type[] { typeof(IPlayer), typeof(ItemBase) } },
			{ (int)ServerEventType.PlayerUseHotkey, new Type[] { typeof(IPlayer), typeof(ActionName) } },
			{ (int)ServerEventType.PlayerUseItem, new Type[] { typeof(IPlayer), typeof(UsableItem) } },
			{ (int)ServerEventType.PlayerReport, new Type[] { typeof(IPlayer), typeof(IPlayer), typeof(string) } },
			{ (int)ServerEventType.PlayerCheaterReport, new Type[] { typeof(IPlayer), typeof(IPlayer), typeof(string) } },
            { (int)ServerEventType.RoundEnd, new Type[0] },
            { (int)ServerEventType.RoundRestart, new Type[0] },
			{ (int)ServerEventType.RoundStart, new Type[0] },
            { (int)ServerEventType.WaitingForPlayers, new Type[0] },
        };

		private static bool ValidateEvent(Type[] parameters, Type[] requiredParameters)
		{
			if (parameters.Length != requiredParameters.Length)
				return false;

			for(int x = 0; x < requiredParameters.Length; x++)
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
			if (!_eventHandlers.ContainsKey(plugin))
				_eventHandlers.Add(plugin, new List<Type>());

			if (!_eventHandlers[plugin].Contains(eventHandler))
				_eventHandlers[plugin].Add(eventHandler);

            if (!_handlerInstances.TryGetValue(eventHandler, out object handle))
			{
				handle = Activator.CreateInstance(eventHandler);
				_handlerInstances.Add(eventHandler, handle);
            }

            foreach (var method in eventHandler.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
                var attribute = method.GetCustomAttribute<Attribute>();

                switch (attribute)
				{
					case PluginEvent pluginEvent:

                        var eventParameters = method.GetParameters().Select(p => p.ParameterType).ToArray();

						if (!ValidateEvent(eventParameters, _requiredParameters[(int)pluginEvent.EventType]))
						{
                            Log.Error($"Event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r contains wrong parameters\n - &6{(string.Join(", ", eventParameters.Select(p => p.Name)))}\n - Required:\n - &6{(string.Join(", ", _requiredParameters[(int)pluginEvent.EventType].Select(p => p.Name)))}.");
                            continue;
						}

						int eventType = (int)pluginEvent.EventType;

                        if (!_registeredEvents.ContainsKey(eventType))
							_registeredEvents.Add(eventType, new List<EventInfo>());

                        switch (pluginEvent.EventType)
                        {
							default:
								_registeredEvents[eventType].Add(new EventInfo()
								{
									Plugin = plugin,
									Target = handle,
									Method = method,
								});

								Log.Info($"Registered event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r!");
                                break;
                        }
						break;
				}
			}
        }

		static PlayerFactory GetPlayerFactory(EventInfo ev)
		{
            if (!FactoryManager.PlayerFactories.TryGetValue(ev.Plugin, out PlayerFactory pFactory))
            {
                pFactory = FactoryManager.PlayerFactories[typeof(EventManager)];
            }
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
			if (!_registeredEvents.TryGetValue((int)type, out List<EventInfo> registeredEvents))
                return true;

            List<object> constructEventParameters = new List<object>();
			List<IndexInfo> indexesToRegenerate = new List<IndexInfo>();
			for(int x = 0; x < _requiredParameters[(int)type].Length; x++)
			{
				var paramType = _requiredParameters[(int)type][x];

                if (args[x] == null)
				{
                    constructEventParameters.Add(null);
					continue;
                }

                if (paramType == typeof(IPlayer))
				{
					indexesToRegenerate.Add(new IndexInfo() { Index = x, Type = paramType });
					constructEventParameters.Add(null);
                }
				else
					constructEventParameters.Add(args[x]);
            }

			bool isCanceled = false;

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
					case bool b:
						if (!b) isCanceled = true;
                        break;
				}
			}

			return !isCanceled;
		}
    }
}
