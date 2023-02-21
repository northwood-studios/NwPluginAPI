using InventorySystem.Items;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information before a player uses an item.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerUseItem"/>.
	/// </remarks>
	/// </summary>
	public class UsingItemEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingItemEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="item"></param>
		/// <param name="cooldown"></param>
		public UsingItemEventArgs(IPlayer player, ItemBase item, float cooldown)
		{
			Player = (Core.Player)player;
			Item = item;
			Cooldown = cooldown;
		}

		/// <summary>
		/// Gets the player who's is going to use the item.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the item to be use.
		/// </summary>
		public ItemBase Item { get; }

		/// <summary>
		/// Get or set the item cooldown.
		/// </summary>
		public float Cooldown { get; set; }
	}
}