using InventorySystem.Items.ThrowableProjectiles;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player attempts to throw a projectile, such as a grenade or a special item that can be thrown.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerThrowProjectile"/>.</remarks>
	/// </summary>
	public class ThrowingProjectileEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ThrowingProjectileEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="item"></param>
		/// <param name="projectileSettings"></param>
		/// <param name="fullForce"></param>
		public ThrowingProjectileEventArgs(IPlayer player, ThrowableItem item,
			ThrowableItem.ProjectileSettings projectileSettings, bool fullForce)
		{
			Player = (Core.Player)player;
			Item = item;
			ProjectileSettings = projectileSettings;
			FullForce = fullForce;
		}

		/// <summary>
		/// Gets the player throwing a projectile.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the <see cref="ThrowableItem"/> being throw.
		/// </summary>
		public ThrowableItem Item { get; }

		/// <summary>
		/// Get or set the <see cref="ThrowableItem.ProjectileSettings"/>.
		/// </summary>
		public ThrowableItem.ProjectileSettings ProjectileSettings { get; set; }

		/// <summary>
		/// Get or set a value indicating if the throw is full force.
		/// </summary>
		public bool FullForce { get; set; }
	}
}