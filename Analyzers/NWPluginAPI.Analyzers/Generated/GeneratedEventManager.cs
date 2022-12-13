using System.Collections.Generic;

public class Event
{
	public readonly EventParameter[] Parameters;

	public Event(params EventParameter[] parameters)
	{
		Parameters = parameters;
	}
}

public class EventParameter
{
	public string BaseType { get; set; }
    public bool IsArray { get; set; }
	public string DefaultIdentifierName { get; set; }

	public EventParameter(string baseType, bool isArray, string defaultIdentifierName)
	{
		BaseType = baseType;
		IsArray = isArray;
		DefaultIdentifierName = defaultIdentifierName;
	}
}

public static class EventManager
{
	public static Dictionary<int, Event> Events = new Dictionary<int, Event>()
	{
		{ 0, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 1, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 2, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "attacker"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", false, "damageHandler")) },
		{ 3, new Event() },
		{ 4, new Event(
			new EventParameter("System.Int32", false, "id")) },
		{ 5, new Event() },
		{ 6, new Event(
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", false, "grenade")) },
		{ 7, new Event(
			new EventParameter("ItemType", false, "item")) },
		{ 8, new Event(
			new EventParameter("MapGeneration.Distributors.Scp079Generator", false, "generator")) },
		{ 9, new Event() },
		{ 10, new Event() },
		{ 11, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", false, "generator")) },
		{ 12, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", false, "firearm"),
			new EventParameter("System.Boolean", false, "isAiming")) },
		{ 13, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "issuer"),
			new EventParameter("System.String", false, "reason"),
			new EventParameter("System.Int64", false, "duration")) },
		{ 14, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Usables.UsableItem", false, "item")) },
		{ 15, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.UInt16", false, "oldItem"),
			new EventParameter("System.UInt16", false, "newItem")) },
		{ 16, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Radio.RadioItem", false, "radio"),
			new EventParameter("System.Byte", false, "range")) },
		{ 17, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "oldTarget"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "newTarget")) },
		{ 18, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", false, "generator")) },
		{ 19, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("AdminToys.ShootingTarget", false, "shootingTarget"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", false, "damageHandler"),
			new EventParameter("System.Single", false, "damageAmount")) },
		{ 20, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("BreakableWindow", false, "window"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", false, "damageHandler"),
			new EventParameter("System.Single", false, "damageAmount")) },
		{ 21, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", false, "generator")) },
		{ 22, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("ItemType", false, "item"),
			new EventParameter("System.Int32", false, "amount")) },
		{ 23, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.ItemBase", false, "item")) },
		{ 24, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", false, "firearm")) },
		{ 25, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PlayerRoles.RoleTypeId", false, "newRole")) },
		{ 26, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target")) },
		{ 27, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target")) },
		{ 28, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", false, "damageHandler")) },
		{ 29, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 30, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.Distributors.Locker", false, "locker"),
			new EventParameter("System.Byte", false, "colliderId"),
			new EventParameter("System.Boolean", false, "canOpen")) },
		{ 31, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 32, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 33, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "issuer"),
			new EventParameter("System.String", false, "reason")) },
		{ 34, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 35, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", false, "generator")) },
		{ 36, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", false, "item")) },
		{ 37, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", false, "item")) },
		{ 38, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", false, "item")) },
		{ 39, new Event(
			new EventParameter("System.String", false, "userId"),
			new EventParameter("System.String", false, "ipAddress"),
			new EventParameter("System.Int64", false, "expiration"),
			new EventParameter("CentralAuthPreauthFlags", false, "centralFlags"),
			new EventParameter("System.String", false, "region"),
			new EventParameter("System.Byte", true, "signature"),
			new EventParameter("LiteNetLib.ConnectionRequest", false, "connectionRequest"),
			new EventParameter("System.Int32", false, "readerStartPosition")) },
		{ 40, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("CustomPlayerEffects.StatusEffectBase", false, "effect"),
			new EventParameter("System.Single", false, "duration")) },
		{ 41, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", false, "firearm")) },
		{ 42, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PlayerRoles.PlayerRoleBase", false, "oldRole"),
			new EventParameter("PlayerRoles.RoleTypeId", false, "newRole"),
			new EventParameter("PlayerRoles.RoleChangeReason", false, "changeReason")) },
		{ 43, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", false, "item")) },
		{ 44, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", false, "item")) },
		{ 45, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", false, "firearm")) },
		{ 46, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PlayerRoles.RoleTypeId", false, "role")) },
		{ 47, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PlayerRoles.IRagdollRole", false, "ragdoll"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", false, "damageHandler")) },
		{ 48, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.ItemBase", false, "item")) },
		{ 49, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.ItemBase", false, "item"),
			new EventParameter("System.Boolean", false, "isToggled")) },
		{ 50, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", false, "firearm")) },
		{ 51, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", false, "generator")) },
		{ 52, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.ItemBase", false, "item")) },
		{ 53, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("ActionName", false, "action")) },
		{ 54, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.Usables.UsableItem", false, "item")) },
		{ 55, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target"),
			new EventParameter("System.String", false, "reason")) },
		{ 56, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target"),
			new EventParameter("System.String", false, "reason")) },
		{ 57, new Event() },
		{ 58, new Event() },
		{ 59, new Event() },
		{ 60, new Event() },
		{ 61, new Event(
			new EventParameter("System.Boolean", false, "isAutomatic"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 62, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 63, new Event() },
		{ 64, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.Boolean", false, "isIntercom")) },
		{ 65, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.Boolean", false, "isIntercom")) },
		{ 66, new Event(
			new EventParameter("System.String", false, "userid"),
			new EventParameter("System.Boolean", false, "hasReservedSlot")) },
		{ 67, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.String", false, "command"),
			new EventParameter("System.String", true, "arguments")) },
		{ 68, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.String", false, "command"),
			new EventParameter("System.String", true, "arguments")) },
		{ 69, new Event(
			new EventParameter("System.String", false, "command"),
			new EventParameter("System.String", true, "arguments")) },
		{ 71, new Event(
			new EventParameter("Respawning.SpawnableTeamType", false, "team")) },
		{ 70, new Event(
			new EventParameter("Respawning.SpawnableTeamType", false, "team")) },
		{ 72, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.Boolean", false, "activated")) },
		{ 74, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 75, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.Boolean", false, "isSuccessful")) },
		{ 76, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.ThrowableProjectiles.ThrowableItem", false, "item"),
			new EventParameter("System.Single", false, "forceAmount"),
			new EventParameter("System.Single", false, "upwardsFactor"),
			new EventParameter("UnityEngine.Vector3", false, "torque"),
			new EventParameter("UnityEngine.Vector3", false, "velocity")) },
		{ 77, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 78, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 79, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("InventorySystem.Items.ItemBase", false, "item")) },
		{ 80, new Event(
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", false, "item")) },
		{ 81, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target")) },
		{ 82, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PlayerRoles.PlayableScps.Scp173.Scp173AudioPlayer+Scp173SoundId", false, "soundId")) },
		{ 83, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 84, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.Boolean", false, "activate")) },
		{ 85, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target")) },
		{ 100, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target")) },
		{ 86, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player")) },
		{ 87, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PlayerRoles.PlayableScps.Scp939.Scp939LungeState", false, "state")) },
		{ 88, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("IDestructible", false, "target")) },
		{ 89, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.Int32", false, "amount"),
			new EventParameter("PlayerRoles.PlayableScps.Scp079.Scp079HudTranslation", false, "reason")) },
		{ 90, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("System.Int32", false, "tier")) },
		{ 91, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("TeslaGate", false, "tesla")) },
		{ 92, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.RoomIdentifier", false, "room")) },
		{ 101, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.RoomIdentifier", false, "room")) },
		{ 93, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("Interactables.Interobjects.DoorUtils.DoorVariant", false, "door")) },
		{ 94, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("Interactables.Interobjects.DoorUtils.DoorVariant", false, "door")) },
		{ 95, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.FacilityZone", false, "zone")) },
		{ 96, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("MapGeneration.RoomIdentifier", false, "room")) },
		{ 97, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target"),
			new EventParameter("BasicRagdoll", false, "body")) },
		{ 98, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "target"),
			new EventParameter("BasicRagdoll", false, "body"),
			new EventParameter("System.Boolean", false, "canResurrct")) },
		{ 99, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", false, "player"),
			new EventParameter("Interactables.Interobjects.DoorUtils.DoorVariant", false, "door"),
			new EventParameter("System.Boolean", false, "canOpen")) },
	};
}
