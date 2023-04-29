using InventorySystem.Items.Pickups;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerPickupArmorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerPickupArmor;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemPickupBase Item { get; }

		public PlayerPickupArmorEvent(ReferenceHub hub, ItemPickupBase item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerPickupArmorEvent() { }
	}
}
