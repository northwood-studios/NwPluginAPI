using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerHandcuff"/>.
	/// </summary>
	public class HandcuffingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="HandcuffingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="target"></param>
		public HandcuffingEventArgs(IPlayer player, IPlayer target)
		{
			Player = (Core.Player)player;
			Target = (Core.Player)target;
		}

		/// <summary>
		/// Get the player who is cuffing.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get the player cuffed.
		/// </summary>
		public Core.Player Target { get; }
	}
}