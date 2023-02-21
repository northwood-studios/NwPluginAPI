using PluginAPI.Core.Interfaces;
using PluginAPI.Core;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerJoined"/>.
	/// </summary>
	public class JoinedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="JoinedEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		public JoinedEventArgs(IPlayer player)
		{
			Player = (Core.Player)player;
		}

		/// <summary>
		/// Gets joined player.
		/// </summary>
		public Core.Player Player { get; }
	}
}