using UnityEngine;

using InventorySystem.Items;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerThrowItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerThrowItem;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }
		[EventArgument]
		public Rigidbody Rigidbody { get; }

		public PlayerThrowItemEvent(ReferenceHub hub, ItemBase item, Rigidbody rb)
		{
			Player = Player.Get(hub);
			Item = item;
			Rigidbody = rb;
		}

		PlayerThrowItemEvent() { }
	}
}
