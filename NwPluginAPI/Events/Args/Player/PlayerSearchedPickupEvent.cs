using InventorySystem.Items.Pickups;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerSearchedPickupEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerSearchedPickup;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemPickupBase Item { get; }

		public PlayerSearchedPickupEvent(ReferenceHub hub, ItemPickupBase item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerSearchedPickupEvent() { }
	}
}
