using InventorySystem.Items;
using InventorySystem.Items.Usables.Scp330;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp330
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerPickupScp330"/>.
	/// </summary>
	public class PickingUpScp330EventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PickingUpScp330EventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="candy"></param>
		public PickingUpScp330EventArgs(IPlayer player, ItemBase candy)
		{
			Player = (Core.Player)player;
			Candy = candy;
		}

		/// <summary>
		/// Gets the player picking a candy.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get the <see cref="ItemBase"/> candy taken.
		/// </summary>
		public ItemBase Candy { get; }
	}
}