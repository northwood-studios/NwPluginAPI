using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information after a player flipped a coin.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerCoinFlip"/>.
	/// </remarks>
	/// </summary>
	public class FlippedCoinEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="FlippedCoinEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="isTails"></param>
		public FlippedCoinEventArgs(IPlayer player, bool isTails)
		{
			Player = (Core.Player)player;
			IsTails = isTails;
		}

		/// <summary>
		/// Gets the player who's flipped the coin.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets if the coin result is tails
		/// </summary>
		public bool IsTails { get; }
	}
}