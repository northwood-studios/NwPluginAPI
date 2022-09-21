using LiteNetLib;

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
		private class IndexInfo
		{
			public int Index;
			public Type Type;
		}

		private static readonly Dictionary<Type, object> EventHandlers = new Dictionary<Type, object>();

		public static readonly Dictionary<ServerEventType, Event> Events = new Dictionary<ServerEventType, Event>()
		{
			{ ServerEventType.PlayerJoined, new Event(
				new EventParameter(typeof(IPlayer), "player")) },
			{ ServerEventType.PlayerLeft, new Event(
				new EventParameter(typeof(IPlayer), "player")) },
			{ ServerEventType.PlayerDeath, new Event(
				new EventParameter(typeof(IPlayer), "player"), 
				new EventParameter(typeof(IPlayer), "attacker"), 
				new EventParameter(typeof(DamageHandlerBase), "damageHandler")) },
			{ ServerEventType.LczDecontaminationStart, new Event() },
			{ ServerEventType.LczDecontaminationAnnouncement, new Event(
				new EventParameter(typeof(int), "id")) },
			{ ServerEventType.MapGenerated, new Event() },
			{ ServerEventType.GrenadeExploded, new Event(
				new EventParameter(typeof(ItemPickupBase), "grenade")) },
			{ ServerEventType.ItemSpawned, new Event(
				new EventParameter(typeof(ItemType), "item")) },
			{ ServerEventType.GeneratorActivated, new Event(
				new EventParameter(typeof(Scp079Generator), "generator")) },
			{ ServerEventType.PlaceBlood, new Event() },
			{ ServerEventType.PlaceBulletHole, new Event() },
			{ ServerEventType.PlayerActivateGenerator, new Event(
				new EventParameter(typeof(IPlayer), "player"), 
				new EventParameter(typeof(Scp079Generator), "generator")) },
			{ ServerEventType.PlayerAimWeapon, new Event(
				new EventParameter(typeof(IPlayer), "player"), 
				new EventParameter(typeof(Firearm), "firearm"), 
				new EventParameter(typeof(bool), "isAiming")) },
			{ ServerEventType.PlayerBanned, new Event(
				new EventParameter(typeof(IPlayer), "player"), 
				new EventParameter(typeof(IPlayer), "issuer"), 
				new EventParameter(typeof(string), "reason"), 
				new EventParameter(typeof(long), "duration")) },
			{ ServerEventType.PlayerCancelUsingItem, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(UsableItem), "item")) },
			{ ServerEventType.PlayerChangeItem, new Event(
				new EventParameter(typeof(IPlayer), "player"), 
				new EventParameter(typeof(ushort), "oldItem"),
				new EventParameter(typeof(ushort), "newItem")) },
			{ ServerEventType.PlayerChangeRadioRange, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(RadioItem), "radio"),
				new EventParameter(typeof(byte), "range")) },
			{ ServerEventType.PlayerChangeSpectator, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IPlayer), "oldTarget"),
				new EventParameter(typeof(IPlayer), "newTarget")) },
			{ ServerEventType.PlayerCloseGenerator, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Scp079Generator), "generator")) },
			{ ServerEventType.PlayerDamagedShootingTarget, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ShootingTarget), "shootingTarget"),
				new EventParameter(typeof(DamageHandlerBase), "damageHandler"),
				new EventParameter(typeof(float), "damageAmount")) },
			{ ServerEventType.PlayerDamagedWindow, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(BreakableWindow), "window"),
				new EventParameter(typeof(DamageHandlerBase), "damageHandler"),
				new EventParameter(typeof(float), "damageAmount")) },
			{ ServerEventType.PlayerDeactivatedGenerator, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Scp079Generator), "generator")) },
			{ ServerEventType.PlayerDropAmmo, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemType), "item"),
				new EventParameter(typeof(int), "amount")) },
			{ ServerEventType.PlayerDropItem,  new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemBase), "item")) },
			{ ServerEventType.PlayerDryfireWeapon, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Firearm), "firearm")) },
			{ ServerEventType.PlayerEscape, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(RoleTypeId), "newRole")) },
			{ ServerEventType.PlayerHandcuff, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IPlayer), "target")) },
			{ ServerEventType.PlayerRemoveHandcuffs, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IPlayer), "target")) },
			{ ServerEventType.PlayerDamage, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IPlayer), "target"),
				new EventParameter(typeof(DamageHandlerBase), "damageHandler")) },
			{ ServerEventType.PlayerInteractElevator, new Event(
				new EventParameter(typeof(IPlayer), "player")) },
			{ ServerEventType.PlayerInteractLocker, new Event(
				new EventParameter(typeof(IPlayer), "player")) },
			{ ServerEventType.PlayerInteractScp330, new Event(
				new EventParameter(typeof(IPlayer), "player")) },
			{ ServerEventType.PlayerInteractShootingTarget, new Event(
				new EventParameter(typeof(IPlayer), "player")) },
			{ ServerEventType.PlayerKicked, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IPlayer), "issuer"),
				new EventParameter(typeof(string), "reason")) },
			{ ServerEventType.PlayerMakeNoise, new Event(
				new EventParameter(typeof(IPlayer), "player")) },
			{ ServerEventType.PlayerOpenGenerator, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Scp079Generator), "generator")) },
			{ ServerEventType.PlayerPickupAmmo, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemPickupBase), "item")) },
			{ ServerEventType.PlayerPickupArmor, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemPickupBase), "item")) },
			{ ServerEventType.PlayerPickupScp330, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemPickupBase), "item")) },
			{ ServerEventType.PlayerPreauth, new Event(
				new EventParameter(typeof(string), "userId"),
				new EventParameter(typeof(string), "ipAddress"),
				new EventParameter(typeof(long), "expiration"),
				new EventParameter(typeof(CentralAuthPreauthFlags), "centralFlags"),
				new EventParameter(typeof(string), "region"),
				new EventParameter(typeof(byte[]), "signature"),
				new EventParameter(typeof(ConnectionRequest), "connectionRequest"),
				new EventParameter(typeof(int), "readerStartPosition")) },
			{ ServerEventType.PlayerReceiveEffect, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(PlayerEffect), "effect")) },
			{ ServerEventType.PlayerReloadWeapon, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Firearm), "firearm")) },
			{ ServerEventType.PlayerChangeRole, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(PlayerRoleBase), "oldRole"),
				new EventParameter(typeof(PlayerRoleBase), "newRole"),
				new EventParameter(typeof(RoleChangeReason), "changeReason")) },
			{ ServerEventType.PlayerSearchPickup, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemPickupBase), "item")) },
			{ ServerEventType.PlayerSearchedPickup, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemPickupBase), "item")) },
			{ ServerEventType.PlayerShotWeapon, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Firearm), "firearm")) },
			{ ServerEventType.PlayerSpawn, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(RoleTypeId), "role")) },
			{ ServerEventType.RagdollSpawn, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IRagdollRole), "ragdoll"),
				new EventParameter(typeof(DamageHandlerBase), "damageHandler")) },
			{ ServerEventType.PlayerThrowItem, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemBase), "item")) },
			{ ServerEventType.PlayerToggleFlashlight, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemBase), "item"),
				new EventParameter(typeof(bool), "isToggled")) },
			{ ServerEventType.PlayerUnloadWeapon, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Firearm), "firearm")) },
			{ ServerEventType.PlayerUnlockGenerator, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(Scp079Generator), "generator")) },
			{ ServerEventType.PlayerUsedItem, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ItemBase), "item")) },
			{ ServerEventType.PlayerUseHotkey, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(ActionName), "action")) },
			{ ServerEventType.PlayerUseItem, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(UsableItem), "item")) },
			{ ServerEventType.PlayerReport, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IPlayer), "target"),
				new EventParameter(typeof(string), "reason")) },
			{ ServerEventType.PlayerCheaterReport, new Event(
				new EventParameter(typeof(IPlayer), "player"),
				new EventParameter(typeof(IPlayer), "target"),
				new EventParameter(typeof(string), "reason")) },
			{ ServerEventType.RoundEnd, new Event() },
			{ ServerEventType.RoundRestart, new Event() },
			{ ServerEventType.RoundStart, new Event() },
			{ ServerEventType.WaitingForPlayers, new Event() },
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
		public static void RegisterEvents<T>(object plugin) where T : Type
		{
			if (!EventHandlers.TryGetValue(typeof(T), out object handler))
			{
				handler = Activator.CreateInstance(typeof(T));
				EventHandlers.Add(typeof(T), handler);
			}

			RegisterEvents(plugin.GetType(), handler);
		} 

		/// <summary>
		/// Registers events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
        static void RegisterEvents(Type plugin, object eventHandler)
		{
            foreach (var method in eventHandler.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
                var attribute = method.GetCustomAttribute<Attribute>();

                switch (attribute)
				{
					case PluginEvent pluginEvent:

						if (!Events.TryGetValue(pluginEvent.EventType, out Event ev))
						{
							Log.Error($"Event &6{pluginEvent.EventType}&r is not registered in manager! ( create issue on github )");
							continue;
						}

                        var eventParameters = method.GetParameters().Select(p => p.ParameterType).ToArray();

						if (!ValidateEvent(eventParameters, ev.Parameters.Select(x => x.BaseType).ToArray()))
						{
                            Log.Error($"Event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r contains wrong parameters\n - &6{(string.Join(", ", eventParameters.Select(p => p.Name)))}\n - Required:\n - &6{(string.Join(", ", ev.Parameters.Select(p => p.BaseType.Name)))}.");
                            continue;
						}

						ev.RegisterInvoker(plugin, eventHandler, method);

                        Log.Info($"Registered event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r!");
                        break;
				}
			}
        }

		private static PlayerFactory GetPlayerFactory(EventInvokeLocation ev)
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
		public static bool ExecuteEvent(ServerEventType type, params object[] args) => ExecuteEvent<bool>(type, args);

		/// <summary>
		/// Executes event.
		/// </summary>
		/// <param name="type">The type of event</param>
		/// <param name="args">The arguments of event.</param>
		/// <returns>Event cancellation data.</returns>
		// ReSharper disable once MemberCanBePrivate.Global
		public static T ExecuteEvent<T>(ServerEventType type, params object[] args) where T : struct
		{
			if (!Events.TryGetValue(type, out Event ev))
			{
				Log.Error($"Event &6{type}&r is not registered in manager! ( create issue on github )");
				return default;
			}

			switch (type)
			{
				case ServerEventType.PlayerJoined:
					if (!(args[0] is IGameComponent component)) break;

					if (!Player.TryGet(component, out Player plr)) break;

					Player.PlayersUserIds.Add(plr.UserId, component);
					break;
			}

            var constructEventParameters = new List<object>();
			var indexesToRegenerate = new List<IndexInfo>();
			
			for (int x = 0; x < ev.Parameters.Length; x++)
			{
				var paramType = ev.Parameters[x].BaseType;

                if (paramType == typeof(IPlayer))
				{
					indexesToRegenerate.Add(new IndexInfo { Index = x, Type = paramType });
					constructEventParameters.Add(null);
                }
				else
					constructEventParameters.Add(args[x]);
            }

			bool isBool = typeof(T) == typeof(bool);
			bool cancelled = false;

			T cancellation;

			if (isBool)
				cancellation = (T)(object)true;
			else cancellation = default;

			foreach(var plugin in ev.Invokers.Values)
			{
				foreach(var invoker in plugin)
				{
					foreach (var index in indexesToRegenerate)
					{
						if (index.Type == typeof(IPlayer))
							constructEventParameters[index.Index] = GetPlayerFactory(invoker).GetOrAdd((IGameComponent)args[index.Index]);
					}

					object result;
					try
					{
						result = invoker.Invoke(constructEventParameters);
					}
					catch (Exception ex)
					{
						Log.Error($"Failed executing event &6{invoker.Method.Name}&r (&6{type}&r) in plugin &6{invoker.Plugin.FullName}&r\n{ex}");
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
