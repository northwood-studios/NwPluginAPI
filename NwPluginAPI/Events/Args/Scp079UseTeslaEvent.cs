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
	public class Scp079UseTeslaEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079UseTesla;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public TeslaGate Tesla { get; }

		public Scp079UseTeslaEvent(ReferenceHub hub, TeslaGate tesla)
		{
			Player = Player.Get(hub);
			Tesla = tesla;
		}
	}
}
