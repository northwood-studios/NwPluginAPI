using InventorySystem.Items.Armor;
using InventorySystem.Items.Pickups;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Items;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerPickupArmor"/>.
	/// </summary>
	public class PickingUpArmorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PickingUpArmorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="pickup"></param>
		public PickingUpArmorEventArgs(IPlayer player, ItemPickupBase pickup)
		{
			Player = (Core.Player)player;
			Armor = pickup;
		}

		/// <summary>
		/// Gets player who is picking up a body armor.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets <see cref="ItemPickupBase"/> of the armor.
		/// </summary>
		public ItemPickupBase Armor { get; }
	}
}