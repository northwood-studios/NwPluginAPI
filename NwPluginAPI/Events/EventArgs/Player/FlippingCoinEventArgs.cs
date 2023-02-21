using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player flipped a coin.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerPreCoinFlip"/>.
	/// </remarks>
	/// </summary>
	public class FlippingCoinEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="FlippingCoinEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		public FlippingCoinEventArgs(IPlayer player)
		{
			Player = (Core.Player)player;
		}

		/// <summary>
		/// Gets the player who is about to flip a coin
		/// </summary>
		public Core.Player Player { get; }
	}
}