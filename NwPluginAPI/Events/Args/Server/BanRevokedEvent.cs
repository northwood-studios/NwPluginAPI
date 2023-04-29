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
	public class BanRevokedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.BanRevoked;
		[EventArgument]
		public string Id { get; }
		[EventArgument]
		public BanType BanType { get; }

		public BanRevokedEvent(string id, BanType type)
		{
			Id = id;
			BanType = type;
		}

		BanRevokedEvent() { }
	}
}
