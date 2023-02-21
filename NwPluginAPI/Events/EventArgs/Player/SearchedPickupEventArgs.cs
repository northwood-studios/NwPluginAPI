using InventorySystem.Items.Pickups;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Items;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerSearchedPickup"/>.
	/// </summary>
	public class SearchedPickupEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="SearchedPickupEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="pickup"></param>
		public SearchedPickupEventArgs(IPlayer player, ItemPickupBase pickup)
		{
			Player = (Core.Player)player;
			Pickup = pickup;
		}

		/// <summary>
		/// Gets the player who's complete searching the pickup.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the pickup searched.
		/// </summary>
		public ItemPickupBase Pickup { get; }
	}
}