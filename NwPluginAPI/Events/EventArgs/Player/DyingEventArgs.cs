using JetBrains.Annotations;
using PlayerStatsSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDying"/>.
	/// </summary>
	public class DyingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DyingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="attacker"></param>
		/// <param name="damageHandlerBase"></param>
		public DyingEventArgs(IPlayer player, IPlayer attacker, DamageHandlerBase damageHandlerBase)
		{
			Player = (Core.Player)player;
			Attacker = (Core.Player)attacker;
			DamageHandler = damageHandlerBase;
		}

		/// <summary>
		/// Gets player who is dying.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the killer player.
		/// </summary>
		[CanBeNull]
		public Core.Player Attacker { get; }

		/// <summary>
		/// Get or set <see cref="DamageHandlerBase"/>
		/// </summary>
		public DamageHandlerBase DamageHandler { get; set; }
	}
}