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
using MapGeneration;

namespace PluginAPI.Events
{
	public class Scp079CancelRoomLockdownEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079CancelRoomLockdown;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public RoomIdentifier Room { get; }

		public Scp079CancelRoomLockdownEvent(ReferenceHub hub, RoomIdentifier room)
		{
			Player = Player.Get(hub);
			Room = room;
		}

		Scp079CancelRoomLockdownEvent() { }
	}
}