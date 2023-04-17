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
using static PlayerRoles.PlayableScps.Scp173.Scp173AudioPlayer;

namespace PluginAPI.Events
{
	public class Scp173PlaySoundEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173PlaySound;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp173SoundId SoundId { get; }

		public Scp173PlaySoundEvent(ReferenceHub hub, Scp173SoundId id)
		{
			Player = Player.Get(hub);
			SoundId = id;
		}

		Scp173PlaySoundEvent() { }
	}
}
