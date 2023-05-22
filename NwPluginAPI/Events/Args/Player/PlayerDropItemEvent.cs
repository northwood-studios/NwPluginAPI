using InventorySystem.Items;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDropItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDropItem;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }

		public PlayerDropItemEvent(ReferenceHub hub, ItemBase item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerDropItemEvent() { }
	}
}
