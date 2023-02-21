using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDropAmmo"/>.
	/// </summary>
	public class DroppingAmmoEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DroppingAmmoEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="ammoType"></param>
		/// <param name="amount"></param>
		public DroppingAmmoEventArgs(IPlayer player, ItemType ammoType, int amount)
		{
			Player = (Core.Player)player;
			AmmoType = ammoType;
			Amount = amount;
		}

		/// <summary>
		/// Gets the player dropping ammo.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets <see cref="ItemType"/> being dropped.
		/// </summary>
		public ItemType AmmoType { get; }

		/// <summary>
		/// Get or set the amount of ammo being dropped.
		/// </summary>
		public int Amount { get; set; }
	}
}