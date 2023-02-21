using InventorySystem.Items.Firearms;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDryfireWeapon"/>.
	/// </summary>
	public class DryWeaponEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DryWeaponEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="weapon"></param>
		public DryWeaponEventArgs(IPlayer player, Firearm weapon)
		{
			Player = (Core.Player)player;
			Weapon = weapon;
		}

		/// <summary>
		/// Gets player who's is drying a weapon
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the <see cref="Firearm"/> being dry.
		/// </summary>
		public Firearm Weapon { get; }
	}
}