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
using PlayerRoles.PlayableScps.Scp079;

namespace PluginAPI.Events
{
	public class Scp079GainExperienceEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079GainExperience;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public int Amount { get; set; }
		[EventArgument]
		public Scp079HudTranslation Reason { get; set; }

		public Scp079GainExperienceEvent(ReferenceHub hub, int amount, Scp079HudTranslation reason)
		{
			Player = Player.Get(hub);
			Amount = amount;
			Reason = reason;
		}

		Scp079GainExperienceEvent() { }
	}
}
