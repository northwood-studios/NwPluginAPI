using InventorySystem.Items.Firearms.Ammo;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerPickupAmmo"/>.
	/// </summary>
	public class PickingUpAmmoEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PickingUpAmmoEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="ammo"></param>
		public PickingUpAmmoEventArgs(IPlayer player, AmmoPickup ammo)
		{
			Player = (Core.Player)player;
			AmmoPickup = ammo;
		}

		/// <summary>
		/// Gets the player picking ammo.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get or set <see cref="InventorySystem.Items.Firearms.Ammo.AmmoPickup"/> what is being picked up.
		/// </summary>
		public AmmoPickup AmmoPickup { get; set; }
	}
}