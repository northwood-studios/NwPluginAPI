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
	public class PlayerGameConsoleCommandExecutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerGameConsoleCommandExecuted;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public string Command { get; }
		[EventArgument]
		public string[] Arguments { get; }
		[EventArgument]
		public bool Result { get; }
		[EventArgument]
		public string Response { get; set; }

		public PlayerGameConsoleCommandExecutedEvent(ReferenceHub hub, string command, string[] args, bool result, string response)
		{
			Player = Player.Get(hub);
			Command = command;
			Arguments = args;
			Result = result;
			Response = response;
		}

		PlayerGameConsoleCommandExecutedEvent() { }
	}
}
