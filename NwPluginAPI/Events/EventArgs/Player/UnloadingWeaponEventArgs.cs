using InventorySystem.Items.Firearms;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerUnloadWeapon"/>.
	/// </summary>
	public class UnloadingWeaponEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UnloadingWeaponEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="weapon"></param>
		public UnloadingWeaponEventArgs(IPlayer player, Firearm weapon)
		{
			Player = (Core.Player)player;
			Firearm = weapon;
		}

		/// <summary>
		/// Gets the player unloading the firearm.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the firearm being unloaded.
		/// </summary>
		public Firearm Firearm { get; }
	}
}