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
using PlayerRoles.Voice;

namespace PluginAPI.Events
{
	public class PlayerUsingIntercomEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUsingIntercom;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public IntercomState IntercomState { get; }

		public PlayerUsingIntercomEvent(ReferenceHub hub, IntercomState state)
		{
			Player = Player.Get(hub);
			IntercomState = state;
		}

		PlayerUsingIntercomEvent() { }
	}
}
