using JetBrains.Annotations;
using PlayerStatsSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDamage"/>.
	/// </summary>
	public class DamagingPlayerEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DamagingPlayerEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="attacker"></param>
		/// <param name="damageHandlerBase"></param>
		public DamagingPlayerEventArgs(IPlayer player, IPlayer attacker, DamageHandlerBase damageHandlerBase)
		{
			Player = (Core.Player)player;
			Attacker = (Core.Player)attacker;
			DamageHandler = damageHandlerBase;
		}

		/// <summary>
		/// Gets damaged player.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the player that is damaging
		/// </summary>
		[CanBeNull]
		public Core.Player Attacker { get; }

		/// <summary>
		/// Get or set <see cref="DamageHandlerBase"/>
		/// </summary>
		public DamageHandlerBase DamageHandler { get; set; }
	}
}