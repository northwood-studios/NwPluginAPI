using InventorySystem.Items.Firearms;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerShotWeapon"/>.
	/// </summary>
	public class ShootingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ShootingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="firearm"></param>
		public ShootingEventArgs(IPlayer player, Firearm firearm)
		{
			Player = (Core.Player)player;
			Firearm = firearm;
		}

		/// <summary>
		/// Gets the player shooting.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the firearm being fired.
		/// </summary>
		public Firearm Firearm { get; }
	}
}