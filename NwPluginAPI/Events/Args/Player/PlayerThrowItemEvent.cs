using InventorySystem.Items;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerThrowItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerThrowItem;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }
		[EventArgument]
		public Rigidbody Rigidbody { get; }

		public PlayerThrowItemEvent(ReferenceHub hub, ItemBase item, Rigidbody rb)
		{
			Player = Core.Player.Get(hub);
			Item = item;
			Rigidbody = rb;
		}

		PlayerThrowItemEvent() { }
	}
}
