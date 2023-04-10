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

namespace PluginAPI.Events
{
	public class PlayerDamagedShootingTargetEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDamagedShootingTarget;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ShootingTarget ShootingTarget { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }
		[EventArgument]
		public float DamageAmount { get; set; }

		public PlayerDamagedShootingTargetEvent(ReferenceHub hub, ShootingTarget target, DamageHandlerBase handler, float damageAmount)
		{
			Player = Player.Get(hub);
			ShootingTarget = target;
			DamageHandler = handler;
			DamageAmount = damageAmount;
		}
	}
}
