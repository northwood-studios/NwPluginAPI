using InventorySystem.Items;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information after a player used a item.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerUsedItem"/>.</remarks>
	/// </summary>
	public class UsedItemEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsedItemEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="itemBase"></param>
		public UsedItemEventArgs(IPlayer player, ItemBase itemBase)
		{
			Player = (Core.Player)player;
			Item = itemBase;
		}

		/// <summary>
		/// Get the player who used the item.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		///  Gets the item that the player used.
		/// </summary>
		public ItemBase Item { get; }
	}
}