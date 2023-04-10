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
	public class PlayerBannedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerBanned;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ICommandSender Issuer { get; }
		[EventArgument]
		public string Reason { get; set; }
		[EventArgument]
		public long Duration { get; set; }

		public PlayerBannedEvent(ReferenceHub hub, ICommandSender issuer, string reason, long duration)
		{
			Player = Player.Get(hub);
			Issuer = issuer;
			Reason = reason;
			Duration = duration;
		}
	}
}
