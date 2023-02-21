using InventorySystem.Items.Pickups;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Items;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerSearchPickup"/>.
	/// </summary>
	public class SearchingPickupEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="SearchingPickupEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="pickup"></param>
		public SearchingPickupEventArgs(IPlayer player, ItemPickupBase pickup)
		{
			Player = (Core.Player)player;
			Pickup = pickup;
		}

		/// <summary>
		/// Gets the player who's searching the pickup.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the pickup being searching.
		/// </summary>
		public ItemPickupBase Pickup { get; }
	}
}