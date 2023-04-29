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
	public class PlayerReceiveEffectEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerReceiveEffect;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public StatusEffectBase Effect { get; }
		[EventArgument]
		public byte Intensity { get; set; }
		[EventArgument]
		public float Duration { get; set; }

		public PlayerReceiveEffectEvent(ReferenceHub hub, StatusEffectBase effect, byte intensity, float duration)
		{
			Player = Player.Get(hub);
			Effect = effect;
			Intensity = intensity;
			Duration = duration;
		}

		PlayerReceiveEffectEvent() { }
	}
}
