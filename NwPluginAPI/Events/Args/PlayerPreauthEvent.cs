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
	public class PlayerPreauthEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerPreauth;
		[EventArgument]
		public string UserId { get; }
		[EventArgument]
		public string IpAddress { get; }
		[EventArgument]
		public long Expiration { get; }
		[EventArgument]
		public CentralAuthPreauthFlags CentralFlags { get; }
		[EventArgument]
		public string Region { get; }
		[EventArgument]
		public byte[] Signature { get; }
		[EventArgument]
		public ConnectionRequest ConnectionRequest { get; }
		[EventArgument]
		public int ReaderStartPosition { get; }

		public PlayerPreauthEvent(string userId, string ipAddress, long expiration, CentralAuthPreauthFlags centralFlags, string region, byte[] signature, ConnectionRequest connectionRequest, int readerStartPosition)
		{
			UserId = userId;
			IpAddress = ipAddress;
			Expiration = expiration;
			CentralFlags = centralFlags;
			Region = region;
			Signature = signature;
			ConnectionRequest = connectionRequest;
			ReaderStartPosition = readerStartPosition;
		}
	}
}
