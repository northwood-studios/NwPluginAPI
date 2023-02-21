using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp330
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerInteractScp330"/>.
	/// </summary>
	public class InteractingScp330EventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="InteractingScp330EventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="candiesTaken"></param>
		public InteractingScp330EventArgs(IPlayer player, int candiesTaken)
		{
			Player = (Core.Player)player;
			CandiesTaken = candiesTaken;
		}

		/// <summary>
		/// Gets the player interacting with SCP-330.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get or set the amount of candies taken of the player.
		/// </summary>
		public int CandiesTaken { get; set; }
	}
}