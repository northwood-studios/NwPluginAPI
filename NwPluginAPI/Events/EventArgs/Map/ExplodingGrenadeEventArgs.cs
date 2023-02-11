using System.Numerics;
using Footprinting;
using InventorySystem.Items.ThrowableProjectiles;
using PluginAPI.Core;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Map
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.GrenadeExploded"/>.
	/// </summary>
	public class ExplodingGrenadeEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ExplodingGrenadeEventArgs"/>.
		/// </summary>
		/// <param name="thrower"></param>
		/// <param name="position"></param>
		/// <param name="grenade"></param>
		public ExplodingGrenadeEventArgs(Footprint thrower, Vector3 position, ExplosionGrenade grenade)
		{
			Player = Core.Player.Get(thrower.Hub);
			Position = position;
			Grenade = grenade;
		}

		/// <summary>
		/// Gets player who's throw a grenade.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get or set grenade position.
		/// </summary>
		public Vector3 Position { get; set; }

		/// <summary>
		/// Gets grenade <see cref="ExplosionGrenade"/> instance.
		/// </summary>
		public ExplosionGrenade Grenade { get; }
	}
}