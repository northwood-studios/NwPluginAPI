using InventorySystem.Items;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUsedItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUsedItem;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }

		public PlayerUsedItemEvent(ReferenceHub hub, ItemBase item)
		{
			Player = Core.Player.Get(hub);
			Item = item;
		}

		PlayerUsedItemEvent() { }
	}
}
