using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information after a player is muted.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerMuted"/>.</remarks>
	/// </summary>
	public class MutedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="MutedEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="isIntercomMute"></param>
		public MutedEventArgs(IPlayer player, bool isIntercomMute)
		{
			Player = (Core.Player)player;
			IsIntercomMute = isIntercomMute;
		}

		/// <summary>
		/// Gets the player being muted.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get value indicating if the player is muted in intercom
		/// </summary>
		public bool IsIntercomMute { get; }
	}
}