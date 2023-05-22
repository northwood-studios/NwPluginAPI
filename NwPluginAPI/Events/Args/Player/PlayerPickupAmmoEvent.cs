using InventorySystem.Items.Pickups;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerPickupAmmoEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerPickupAmmo;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemPickupBase Item { get; }

		public PlayerPickupAmmoEvent(ReferenceHub hub, ItemPickupBase item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerPickupAmmoEvent() { }
	}
}
