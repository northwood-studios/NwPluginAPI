using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player is reported for breaking the server rules
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerReport"/>.
	/// </remarks>
	/// </summary>
	public class ReportingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ReportingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="target"></param>
		/// <param name="reason"></param>
		public ReportingEventArgs(IPlayer player, IPlayer target, string reason)
		{
			Player = (Core.Player)player;
			Target = (Core.Player)target;
			Reason = reason;
		}

		/// <summary>
		/// Gets the player who is reporting.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the player reported.
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Get or set the reason of the report.
		/// </summary>
		public string Reason { get; set; }
	}
}