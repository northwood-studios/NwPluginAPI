using InventorySystem.Items.Firearms.Ammo;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDroppedAmmoEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDroppedAmmo;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public AmmoPickup Item { get; set; }
		[EventArgument]
		public int Amount { get; set; }
		[EventArgument]
		public int MaxAmount { get; set; }

		public PlayerDroppedAmmoEvent(ReferenceHub hub, AmmoPickup item, int amount, int maxAmount)
		{
			Player = Core.Player.Get(hub);
			Item = item;
			Amount = amount;
			MaxAmount = maxAmount;
		}

		PlayerDroppedAmmoEvent() { }
	}
}
