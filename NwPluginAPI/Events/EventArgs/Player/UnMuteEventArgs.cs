using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information after a player is unmuted.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerUnmuted"/>.</remarks>
	/// </summary>
	public class UnMuteEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UnMuteEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="isIntercomMute"></param>
		public UnMuteEventArgs(IPlayer player, bool isIntercomMute)
		{
			Player = (Core.Player)player;
			IsIntercomMute = isIntercomMute;
		}

		/// <summary>
		/// Gets the player being unmuted.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets a value indicating if the removing mute is for intercom.
		/// </summary>
		public bool IsIntercomMute { get; }
	}
}