using InventorySystem.Items.Pickups;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDroppedItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDropedpItem;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ItemPickupBase Item { get; }

		public PlayerDroppedItemEvent(ReferenceHub hub, ItemPickupBase item)
		{
			Player = Core.Player.Get(hub);
			Item = item;
		}

		PlayerDroppedItemEvent() { }
	}
}
