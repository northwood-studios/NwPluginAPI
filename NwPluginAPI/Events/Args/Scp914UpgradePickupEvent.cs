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
using Scp914;

namespace PluginAPI.Events
{
	public class Scp914UpgradePickupEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914UpgradePickup;
		[EventArgument]
		public ItemPickupBase Item { get; set; }
		[EventArgument]
		public Vector3 OutputPosition { get; set; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; set; }
	}
}
