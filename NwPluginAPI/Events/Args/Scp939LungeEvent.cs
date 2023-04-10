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
using PlayerRoles.PlayableScps.Scp939;

namespace PluginAPI.Events
{
	public class Scp939LungeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp939Lunge;
		[EventArgument]
		public Player Player { get; set; }
		[EventArgument]
		public Scp939LungeState State { get; set; }
	}
}
