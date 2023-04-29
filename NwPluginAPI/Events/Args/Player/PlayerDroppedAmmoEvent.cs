using LiteNetLib;
using UnityEngine;

using AdminToys;
using PlayerRoles;
using Footprinting;
using CustomPlayerEffects;
using MapGeneration.Distributors;

using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;

using CommandSystem;
using PlayerStatsSystem;

using InventorySystem.Items;
using InventorySystem.Items.Radio;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.Usables;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.ThrowableProjectiles;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

using static BanHandler;
using static MapGeneration.Distributors.Scp079Generator;
using InventorySystem.Items.Firearms.Ammo;

namespace PluginAPI.Events
{
	public class PlayerDroppedAmmoEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDroppedAmmo;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public AmmoPickup Item { get; set; }
		[EventArgument]
		public int Amount { get; set; }
		[EventArgument]
		public int MaxAmount { get; set; }

		public PlayerDroppedAmmoEvent(ReferenceHub hub, AmmoPickup item, int amount, int maxAmount)
		{
			Player = Player.Get(hub);
			Item = item;
			Amount = amount;
			MaxAmount = maxAmount;
		}

		PlayerDroppedAmmoEvent() { }
	}
}
