using InventorySystem.Items;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerUsedItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUsedItem;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }

		public PlayerUsedItemEvent(ReferenceHub hub, ItemBase item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerUsedItemEvent() { }
	}
}
