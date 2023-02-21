using InventorySystem.Items;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Items;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDropItem"/>.
	/// </summary>
	public class DroppingItemEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DroppingAmmoEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="item"></param>
		public DroppingItemEventArgs(IPlayer player, ItemBase item)
		{
			Player = (Core.Player)player;
			Item = Item.GetOrAdd<Item>(item);
		}

		/// <summary>
		/// Gets the player dropping a item.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the item being dropped
		/// </summary>
		public Item Item { get; }
	}
}