using InventorySystem.Items.Firearms;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerAimWeapon"/>.
	/// </summary>
	public class AimingWeaponEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="AimingWeaponEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="weapon"></param>
		/// <param name="adsInOrOut"></param>
		public AimingWeaponEventArgs(IPlayer player, Firearm weapon, bool adsInOrOut)
		{
			Player = (Core.Player)player;
			Weapon = weapon;
			IsAiming = adsInOrOut;
		}

		/// <summary>
		/// Gets the player who is triggering this action
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		///	Gets the <see cref="Firearm"/> weapon who is trigger this action.
		/// </summary>
		public Firearm Weapon { get; }

		/// <summary>
		/// Gets a value indicating if the player is aiming or not.
		/// </summary>
		public bool IsAiming { get; }
	}
}