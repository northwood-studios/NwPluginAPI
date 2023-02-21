using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerLeft"/>.
	/// </summary>
	public class LeftEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="LeftEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		public LeftEventArgs(IPlayer player)
		{
			Player = (Core.Player)player;
		}

		/// <summary>
		/// Get player who left the server.
		/// </summary>
		public Core.Player Player { get; }
	}
}