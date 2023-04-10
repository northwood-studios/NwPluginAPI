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
using static InventorySystem.Items.ThrowableProjectiles.ThrowableItem;

namespace PluginAPI.Events
{
	public class PlayerThrowProjectileEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerThrowProjectile;
		[EventArgument]
		public Player Thrower { get; set; }
		[EventArgument]
		public ThrowableItem Item { get; set; }
		[EventArgument]
		public ProjectileSettings ProjectileSettings { get; set; }
		[EventArgument]
		public bool FullForce { get; set; }
	}
}
