using InventorySystem.Items;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDropItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDropItem;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }

		public PlayerDropItemEvent(ReferenceHub hub, ItemBase item)
		{
			Player = Core.Player.Get(hub);
			Item = item;
		}

		PlayerDropItemEvent() { }
	}
}
