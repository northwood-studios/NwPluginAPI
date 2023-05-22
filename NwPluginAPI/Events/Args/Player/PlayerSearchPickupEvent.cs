using InventorySystem.Items.Pickups;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerSearchPickupEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerSearchPickup;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemPickupBase Item { get; }

		public PlayerSearchPickupEvent(ReferenceHub hub, ItemPickupBase item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerSearchPickupEvent() { }
	}
}
