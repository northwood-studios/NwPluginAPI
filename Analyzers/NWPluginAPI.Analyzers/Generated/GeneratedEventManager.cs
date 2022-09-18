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
	public string DefaultIdentifierName { get; set; }

	public EventParameter(string baseType, string defaultIdentifierName)
	{
		BaseType = baseType;
		DefaultIdentifierName = defaultIdentifierName;
	}
}

public static class EventManager
{
	public static Dictionary<int, Event> Events = new Dictionary<int, Event>()
	{
		{ 0, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player")) },
		{ 1, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player")) },
		{ 2, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "attacker"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", "damageHandler")) },
		{ 3, new Event() },
		{ 4, new Event(
			new EventParameter("System.Int32", "id")) },
		{ 5, new Event() },
		{ 6, new Event(
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", "grenade")) },
		{ 7, new Event(
			new EventParameter("ItemType", "item")) },
		{ 8, new Event(
			new EventParameter("MapGeneration.Distributors.Scp079Generator", "generator")) },
		{ 9, new Event() },
		{ 10, new Event() },
		{ 11, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", "generator")) },
		{ 12, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", "firearm"),
			new EventParameter("System.Boolean", "isAiming")) },
		{ 13, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "issuer"),
			new EventParameter("System.String", "reason"),
			new EventParameter("System.Int64", "duration")) },
		{ 14, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Usables.UsableItem", "item")) },
		{ 15, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("System.UInt16", "oldItem"),
			new EventParameter("System.UInt16", "newItem")) },
		{ 16, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Radio.RadioItem", "radio"),
			new EventParameter("System.Byte", "range")) },
		{ 17, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "oldTarget"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "newTarget")) },
		{ 18, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", "generator")) },
		{ 19, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("AdminToys.ShootingTarget", "shootingTarget"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", "damageHandler"),
			new EventParameter("System.Single", "damageAmount")) },
		{ 20, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("BreakableWindow", "window"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", "damageHandler"),
			new EventParameter("System.Single", "damageAmount")) },
		{ 21, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", "generator")) },
		{ 22, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("ItemType", "item"),
			new EventParameter("System.Int32", "amount")) },
		{ 23, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.ItemBase", "item")) },
		{ 24, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", "firearm")) },
		{ 25, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PlayerRoles.RoleTypeId", "newRole")) },
		{ 26, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "target")) },
		{ 27, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "target")) },
		{ 28, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "target"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", "damageHandler")) },
		{ 29, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player")) },
		{ 30, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player")) },
		{ 31, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player")) },
		{ 32, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player")) },
		{ 33, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "issuer"),
			new EventParameter("System.String", "reason")) },
		{ 34, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player")) },
		{ 35, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", "generator")) },
		{ 36, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", "item")) },
		{ 37, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", "item")) },
		{ 38, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", "item")) },
		{ 39, new Event(
			new EventParameter("System.String", "userId"),
			new EventParameter("System.String", "ipAddress"),
			new EventParameter("System.Int64", "expiration"),
			new EventParameter("CentralAuthPreauthFlags", "centralFlags"),
			new EventParameter("System.String", "region"),
			new EventParameter("System.Byte[]", "signature")) },
		{ 40, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("CustomPlayerEffects.PlayerEffect", "effect")) },
		{ 41, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", "firearm")) },
		{ 42, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PlayerRoles.PlayerRoleBase", "oldRole"),
			new EventParameter("PlayerRoles.PlayerRoleBase", "newRole"),
			new EventParameter("PlayerRoles.RoleChangeReason", "changeReason")) },
		{ 43, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", "item")) },
		{ 44, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Pickups.ItemPickupBase", "item")) },
		{ 45, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", "firearm")) },
		{ 46, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PlayerRoles.RoleTypeId", "role")) },
		{ 47, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PlayerRoles.IRagdollRole", "ragdoll"),
			new EventParameter("PlayerStatsSystem.DamageHandlerBase", "damageHandler")) },
		{ 48, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.ItemBase", "item")) },
		{ 49, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.ItemBase", "item"),
			new EventParameter("System.Boolean", "isToggled")) },
		{ 50, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Firearms.Firearm", "firearm")) },
		{ 51, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("MapGeneration.Distributors.Scp079Generator", "generator")) },
		{ 52, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.ItemBase", "item")) },
		{ 53, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("ActionName", "action")) },
		{ 54, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("InventorySystem.Items.Usables.UsableItem", "item")) },
		{ 55, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "target"),
			new EventParameter("System.String", "reason")) },
		{ 56, new Event(
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "player"),
			new EventParameter("PluginAPI.Core.Interfaces.IPlayer", "target"),
			new EventParameter("System.String", "reason")) },
		{ 57, new Event() },
		{ 58, new Event() },
		{ 59, new Event() },
		{ 60, new Event() },
	};
}
