using InventorySystem.Items.Firearms;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerReloadWeapon"/>.
	/// </summary>
	public class ReloadingWeaponEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ReloadingWeaponEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="weapon"></param>
		public ReloadingWeaponEventArgs(IPlayer player, Firearm weapon)
		{
			Player = (Core.Player)player;
			Firearm = weapon;
		}

		/// <summary>
		/// Gets the player who is reloading the weapon.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the firearm being reloaded.
		/// </summary>
		public Firearm Firearm { get; }
	}
}