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
using PlayerRoles.PlayableScps.Scp096;

namespace PluginAPI.Events
{
	public class Scp096ChangeStateEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096ChangeState;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp096RageState RageState { get; }

		public Scp096ChangeStateEvent(ReferenceHub hub, Scp096RageState state)
		{
			Player = Player.Get(hub);
			RageState = state;
		}

		Scp096ChangeStateEvent() { }
	}
}
