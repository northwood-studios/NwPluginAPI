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
		public Core.Player Player { get; }
		[EventArgument]
		public ItemPickupBase Item { get; }

		public PlayerPickupAmmoEvent(ReferenceHub hub, ItemPickupBase item)
		{
			Player = Core.Player.Get(hub);
			Item = item;
		}

		PlayerPickupAmmoEvent() { }
	}
}
