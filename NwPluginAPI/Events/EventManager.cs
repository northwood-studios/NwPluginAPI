using Footprinting;
using PlayerRoles.PlayableScps.Scp079.Cameras;
using PlayerRoles.PlayableScps.Scp096;

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
		public static readonly Dictionary<ServerEventType, Event> Events = new Dictionary<ServerEventType, Event>()
		{
			{
				ServerEventType.PlayerJoined, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.PlayerLeft, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.PlayerDying, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "attacker"),
					new EventParameter(typeof(DamageHandlerBase), "damageHandler"))
			},
			{ ServerEventType.LczDecontaminationStart, new Event() },
			{
				ServerEventType.LczDecontaminationAnnouncement, new Event(
					new EventParameter(typeof(int), "id"))
			},
			{ ServerEventType.MapGenerated, new Event() },
			{
				ServerEventType.GrenadeExploded, new Event(
					new EventParameter(typeof(Footprint), "thrower"),
					new EventParameter(typeof(Vector3), "position"),
					new EventParameter(typeof(ItemPickupBase), "grenade"))
			},
			{
				ServerEventType.ItemSpawned, new Event(
					new EventParameter(typeof(ItemType), "item"),
					new EventParameter(typeof(Vector3), "position"))
			},
			{
				ServerEventType.GeneratorActivated, new Event(
					new EventParameter(typeof(Scp079Generator), "generator"))
			},
			{
				ServerEventType.PlaceBlood, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Vector3), "position"))
			},
			{
				ServerEventType.PlaceBulletHole, new Event(
					new EventParameter(typeof(Vector3), "position"))
			},
			{
				ServerEventType.PlayerActivateGenerator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp079Generator), "generator"))
			},
			{
				ServerEventType.PlayerAimWeapon, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Firearm), "firearm"),
					new EventParameter(typeof(bool), "isAiming"))
			},
			{
				ServerEventType.PlayerBanned, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ICommandSender), "issuer"),
					new EventParameter(typeof(string), "reason"),
					new EventParameter(typeof(long), "duration"))
			},
			{
				ServerEventType.PlayerCancelUsingItem, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(UsableItem), "item"))
			},
			{
				ServerEventType.PlayerChangeItem, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ushort), "oldItem"),
					new EventParameter(typeof(ushort), "newItem"))
			},
			{
				ServerEventType.PlayerChangeRadioRange, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(RadioItem), "radio"),
					new EventParameter(typeof(byte), "range"))
			},
			{
				ServerEventType.PlayerChangeSpectator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "oldTarget"),
					new EventParameter(typeof(IPlayer), "newTarget"))
			},
			{
				ServerEventType.PlayerCloseGenerator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp079Generator), "generator"))
			},
			{
				ServerEventType.PlayerDamagedShootingTarget, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ShootingTarget), "shootingTarget"),
					new EventParameter(typeof(DamageHandlerBase), "damageHandler"),
					new EventParameter(typeof(float), "damageAmount"))
			},
			{
				ServerEventType.PlayerDamagedWindow, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(BreakableWindow), "window"),
					new EventParameter(typeof(DamageHandlerBase), "damageHandler"),
					new EventParameter(typeof(float), "damageAmount"))
			},
			{
				ServerEventType.PlayerDeactivatedGenerator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp079Generator), "generator"))
			},
			{
				ServerEventType.PlayerDropAmmo, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemType), "item"),
					new EventParameter(typeof(int), "amount"))
			},
			{
				ServerEventType.PlayerDropItem, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemBase), "item"))
			},
			{
				ServerEventType.PlayerDryfireWeapon, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Firearm), "firearm"))
			},
			{
				ServerEventType.PlayerEscape, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(RoleTypeId), "newRole"))
			},
			{
				ServerEventType.PlayerHandcuff, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"))
			},
			{
				ServerEventType.PlayerRemoveHandcuffs, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"))
			},
			{
				ServerEventType.PlayerDamage, new Event(
					new EventParameter(typeof(IPlayer), "target"),
					new EventParameter(typeof(IPlayer), "attacker"),
					new EventParameter(typeof(DamageHandlerBase), "damageHandler"))
			},
			{
				ServerEventType.PlayerInteractElevator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ElevatorChamber), "elevator"))
			},
			{
				ServerEventType.PlayerInteractLocker, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Locker), "locker"),
					new EventParameter(typeof(LockerChamber), "chamber"),
					new EventParameter(typeof(bool), "canOpen"))
			},
			{
				ServerEventType.PlayerInteractScp330, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.PlayerInteractShootingTarget, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ShootingTarget), "shootingTarget"))
			},
			{
				ServerEventType.PlayerKicked, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ICommandSender), "issuer"),
					new EventParameter(typeof(string), "reason"))
			},
			{
				ServerEventType.PlayerMakeNoise, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.PlayerOpenGenerator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp079Generator), "generator"))
			},
			{
				ServerEventType.PlayerPickupAmmo, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemPickupBase), "item"))
			},
			{
				ServerEventType.PlayerPickupArmor, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemPickupBase), "item"))
			},
			{
				ServerEventType.PlayerPickupScp330, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemPickupBase), "item"))
			},
			{
				ServerEventType.PlayerPreauth, new Event(
					new EventParameter(typeof(string), "userId"),
					new EventParameter(typeof(string), "ipAddress"),
					new EventParameter(typeof(long), "expiration"),
					new EventParameter(typeof(CentralAuthPreauthFlags), "centralFlags"),
					new EventParameter(typeof(string), "region"),
					new EventParameter(typeof(byte[]), "signature"),
					new EventParameter(typeof(ConnectionRequest), "connectionRequest"),
					new EventParameter(typeof(int), "readerStartPosition"))
			},
			{
				ServerEventType.PlayerReceiveEffect, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(StatusEffectBase), "effect"),
					new EventParameter(typeof(byte), "intensity"),
					new EventParameter(typeof(float), "duration"))
			},
			{
				ServerEventType.PlayerReloadWeapon, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Firearm), "firearm"))
			},
			{
				ServerEventType.PlayerChangeRole, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(PlayerRoleBase), "oldRole"),
					new EventParameter(typeof(RoleTypeId), "newRole"),
					new EventParameter(typeof(RoleChangeReason), "changeReason"))
			},
			{
				ServerEventType.PlayerSearchPickup, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemPickupBase), "item"))
			},
			{
				ServerEventType.PlayerSearchedPickup, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemPickupBase), "item"))
			},
			{
				ServerEventType.PlayerShotWeapon, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Firearm), "firearm"))
			},
			{
				ServerEventType.PlayerSpawn, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(RoleTypeId), "role"))
			},
			{
				ServerEventType.RagdollSpawn, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IRagdollRole), "ragdoll"),
					new EventParameter(typeof(DamageHandlerBase), "damageHandler"))
			},
			{
				ServerEventType.PlayerThrowItem, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemBase), "item"),
					new EventParameter(typeof(Rigidbody), "rigidbody"))
			},
			{
				ServerEventType.PlayerToggleFlashlight, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemBase), "item"),
					new EventParameter(typeof(bool), "isToggled"))
			},
			{
				ServerEventType.PlayerUnloadWeapon, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Firearm), "firearm"))
			},
			{
				ServerEventType.PlayerUnlockGenerator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp079Generator), "generator"))
			},
			{
				ServerEventType.PlayerUsedItem, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemBase), "item"))
			},
			{
				ServerEventType.PlayerUseHotkey, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ActionName), "action"))
			},
			{
				ServerEventType.PlayerUseItem, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(UsableItem), "item"))
			},
			{
				ServerEventType.PlayerReport, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"),
					new EventParameter(typeof(string), "reason"))
			},
			{
				ServerEventType.PlayerCheaterReport, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"),
					new EventParameter(typeof(string), "reason"))
			},
			{
				ServerEventType.RoundEnd, new Event(
					new EventParameter(typeof(RoundSummary.LeadingTeam), "leadingTeam"))
			},
			{ ServerEventType.RoundRestart, new Event() },
			{ ServerEventType.RoundStart, new Event() },
			{ ServerEventType.WaitingForPlayers, new Event() },
			{
				ServerEventType.WarheadStart, new Event(
					new EventParameter(typeof(bool), "isAutomatic"),
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(bool), "isResumed"))
			},
			{
				ServerEventType.WarheadStop, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{ ServerEventType.WarheadDetonation, new Event() },
			{
				ServerEventType.PlayerMuted, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(bool), "isIntercom"))
			},
			{
				ServerEventType.PlayerUnmuted, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(bool), "isIntercom"))
			},
			{
				ServerEventType.PlayerCheckReservedSlot, new Event(
					new EventParameter(typeof(string), "userid"),
					new EventParameter(typeof(bool), "hasReservedSlot"))
			},
			{
				ServerEventType.RemoteAdminCommand, new Event(
					new EventParameter(typeof(ICommandSender), "sender"),
					new EventParameter(typeof(string), "command"),
					new EventParameter(typeof(string[]), "arguments"))
			},
			{
				ServerEventType.PlayerGameConsoleCommand, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(string), "command"),
					new EventParameter(typeof(string[]), "arguments"))
			},
			{
				ServerEventType.ConsoleCommand, new Event(
					new EventParameter(typeof(ICommandSender), "sender"),
					new EventParameter(typeof(string), "command"),
					new EventParameter(typeof(string[]), "arguments"))
			},
			{
				ServerEventType.TeamRespawn, new Event(
					new EventParameter(typeof(SpawnableTeamType), "team"))
			},
			{
				ServerEventType.TeamRespawnSelected, new Event(
					new EventParameter(typeof(SpawnableTeamType), "team"))
			},
			{
				ServerEventType.Scp106Stalking, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(bool), "activated"))
			},
			{
				ServerEventType.PlayerEnterPocketDimension, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.PlayerExitPocketDimension, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(bool), "isSuccessful"))
			},
			{
				ServerEventType.PlayerThrowProjectile, new Event(
					new EventParameter(typeof(IPlayer), "thrower"),
					new EventParameter(typeof(ThrowableItem), "item"),
					new EventParameter(typeof(ThrowableItem.ProjectileSettings), "projectileSettings"),
					new EventParameter(typeof(bool), "fullForce"))
			},
			{
				ServerEventType.Scp914Activate, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp914KnobSetting), "knobSetting"))
			},
			{
				ServerEventType.Scp914KnobChange, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp914KnobSetting), "knobSetting"),
					new EventParameter(typeof(Scp914KnobSetting), "previousKnobSetting"))
			},
			{
				ServerEventType.Scp914UpgradeInventory, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemBase), "item"),
					new EventParameter(typeof(Scp914KnobSetting), "knobSetting"))
			},
			{
				ServerEventType.Scp914UpgradePickup, new Event(
					new EventParameter(typeof(ItemPickupBase), "item"),
					new EventParameter(typeof(Vector3), "outputPosition"),
					new EventParameter(typeof(Scp914KnobSetting), "knobSetting"))
			},
			{
				ServerEventType.Scp106TeleportPlayer, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"))
			},
			{
				ServerEventType.Scp173PlaySound, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp173AudioPlayer.Scp173SoundId), "soundId"))
			},
			{
				ServerEventType.Scp173CreateTantrum, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.Scp173BreakneckSpeeds, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(bool), "activate"))
			},
			{
				ServerEventType.Scp173NewObserver, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"))
			},
			{
				ServerEventType.Scp173SnapPlayer, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"))
			},
			{
				ServerEventType.Scp939CreateAmnesticCloud, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.Scp939Lunge, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp939LungeState), "state"))
			},
			{
				ServerEventType.Scp939Attack, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IDestructible), "target"))
			},
			{
				ServerEventType.Scp079GainExperience, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(int), "amount"),
					new EventParameter(typeof(Scp079HudTranslation), "reason"))
			},
			{
				ServerEventType.Scp079LevelUpTier, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(int), "tier"))
			},
			{
				ServerEventType.Scp079UseTesla, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(TeslaGate), "tesla"))
			},
			{
				ServerEventType.Scp079LockdownRoom, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(RoomIdentifier), "room"))
			},
			{
				ServerEventType.Scp079CancelRoomLockdown, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(RoomIdentifier), "room"))
			},
			{
				ServerEventType.Scp079LockDoor, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(DoorVariant), "door"))
			},
			{
				ServerEventType.Scp079UnlockDoor, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(DoorVariant), "door"))
			},
			{
				ServerEventType.Scp079BlackoutZone, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(FacilityZone), "zone"))
			},
			{
				ServerEventType.Scp079BlackoutRoom, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(RoomIdentifier), "room"))
			},
			{
				ServerEventType.Scp049ResurrectBody, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"),
					new EventParameter(typeof(BasicRagdoll), "body"))
			},
			{
				ServerEventType.Scp049StartResurrectingBody, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"),
					new EventParameter(typeof(BasicRagdoll), "body"),
					new EventParameter(typeof(bool), "canResurrct"))
			},
			{
				ServerEventType.PlayerInteractDoor, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(DoorVariant), "door"),
					new EventParameter(typeof(bool), "canOpen"))
			},
			{
				ServerEventType.BanIssued, new Event(
					new EventParameter(typeof(BanDetails), "banDetails"),
					new EventParameter(typeof(BanHandler.BanType), "banType"))
			},
			{
				ServerEventType.BanRevoked, new Event(
					new EventParameter(typeof(string), "id"),
					new EventParameter(typeof(BanHandler.BanType), "banType"))
			},
			{
				ServerEventType.RemoteAdminCommandExecuted, new Event(
					new EventParameter(typeof(ICommandSender), "sender"),
					new EventParameter(typeof(string), "command"),
					new EventParameter(typeof(string[]), "arguments"),
					new EventParameter(typeof(bool), "result"),
					new EventParameter(typeof(string), "response"))
			},
			{
				ServerEventType.PlayerGameConsoleCommandExecuted, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(string), "command"),
					new EventParameter(typeof(string[]), "arguments"),
					new EventParameter(typeof(bool), "result"),
					new EventParameter(typeof(string), "response"))
			},
			{
				ServerEventType.ConsoleCommandExecuted, new Event(
					new EventParameter(typeof(ICommandSender), "sender"),
					new EventParameter(typeof(string), "command"),
					new EventParameter(typeof(string[]), "arguments"),
					new EventParameter(typeof(bool), "result"),
					new EventParameter(typeof(string), "response"))
			},
			{
				ServerEventType.BanUpdated, new Event(
					new EventParameter(typeof(BanDetails), "banDetails"),
					new EventParameter(typeof(BanHandler.BanType), "banType"))
			},
			{
				ServerEventType.PlayerPreCoinFlip, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.PlayerCoinFlip, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(bool), "isTails"))
			},
			{
				ServerEventType.PlayerInteractGenerator, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp079Generator), "generator"),
					new EventParameter(typeof(Scp079Generator.GeneratorColliderId), "generatorColliderId"))
			},
			{
				ServerEventType.RoundEndConditionsCheck, new Event(
					new EventParameter(typeof(bool), "baseGameConditionsSatisfied"))
			},
			{
				ServerEventType.Scp914PickupUpgraded, new Event(
					new EventParameter(typeof(ItemPickupBase), "item"),
					new EventParameter(typeof(Vector3), "newPosition"),
					new EventParameter(typeof(Scp914KnobSetting), "knobSetting"))
			},
			{
				ServerEventType.Scp914InventoryItemUpgraded, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(ItemBase), "item"),
					new EventParameter(typeof(Scp914KnobSetting), "knobSetting"))
			},
			{
				ServerEventType.Scp914ProcessPlayer, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp914KnobSetting), "knobSetting"),
					new EventParameter(typeof(Vector3), "outPosition"))
			},
			{
				ServerEventType.Scp079CameraChanged, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp079Camera), "camera"))
			},
			{
				ServerEventType.Scp096AddingTarget, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "target"),
					new EventParameter(typeof(bool), "isForLook")
					)
			},
			{
				ServerEventType.Scp096Enraging, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(float), "initialDuration"))
			},
			{
				ServerEventType.Scp096ChangeState, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(Scp096RageState), "rageState"))
			},
			{
				ServerEventType.Scp096Charging, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.Scp096PryingGate, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(PryableDoor), "gateDoor"))
			},
			{
				ServerEventType.Scp096TryNotCry, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.Scp096StartCrying, new Event(
					new EventParameter(typeof(IPlayer), "player"))
			},
			{
				ServerEventType.PlayerUsingRadio, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(RadioItem), "radio"),
					new EventParameter(typeof(float), "drain")
					)
			},
			{
				ServerEventType.CassieAnnouncesScpTermination, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(DamageHandlerBase), "damageHandler"),
					new EventParameter(typeof(String), "announcement")
					)
			},
			{
				ServerEventType.PlayerChangingGroup, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(UserGroup), "group")
					)
			},
			{
				ServerEventType.PlayerUsingIntercom, new Event(
					new EventParameter(typeof(IPlayer), "player")
					)
			},
			{
				ServerEventType.PlayerDeath, new Event(
					new EventParameter(typeof(IPlayer), "player"),
					new EventParameter(typeof(IPlayer), "attacker"),
					new EventParameter(typeof(DamageHandlerBase), "damageHandler"))
			},

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

							Log.Debug($"Registered event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r!", Log.DebugMode);
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
				foreach (var invoker in ev.Value.Invokers)
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
						result = invoker.Invoke(ev.RegenerateParameters(invoker, args));
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
