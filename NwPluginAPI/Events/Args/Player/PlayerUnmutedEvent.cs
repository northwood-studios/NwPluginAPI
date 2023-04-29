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
	public class PlayerUnmutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUnmuted;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Issuer { get; }
		[EventArgument]
		public bool IsIntercom { get; }

		public PlayerUnmutedEvent(ReferenceHub hub, ReferenceHub issuer, bool isIntercom)
		{
			Player = Player.Get(hub);
			Issuer = issuer == ReferenceHub.HostHub ? Server.Instance : Player.Get(issuer);
			IsIntercom = isIntercom;
		}

		PlayerUnmutedEvent() { }
	}
}
