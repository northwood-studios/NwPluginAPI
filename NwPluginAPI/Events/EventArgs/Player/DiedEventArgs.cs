using PlayerStatsSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	///Contains all the information after a player died.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDeath"/>.
	/// </remarks>
	/// </summary>
	public class DiedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DiedEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="killer"></param>
		/// <param name="damage"></param>
		public DiedEventArgs(IPlayer player, IPlayer killer, DamageHandlerBase damage)
		{
			Player = (Core.Player)player;
			Killer = (Core.Player)killer;
			Damage = damage;
		}

		/// <summary>
		/// Gets the player who is dead.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the killer player.
		/// </summary>
		public Core.Player Killer { get; }

		/// <summary>
		/// Gets <see cref="DamageHandlerBase"/> of the event.
		/// </summary>
		public DamageHandlerBase Damage { get; }
	}
}