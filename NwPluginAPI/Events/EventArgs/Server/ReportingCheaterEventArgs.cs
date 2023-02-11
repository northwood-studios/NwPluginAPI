using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerCheaterReport"/>.
	/// </summary>
	public class ReportingCheaterEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ReportingCheaterEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="target"></param>
		/// <param name="reason"></param>
		public ReportingCheaterEventArgs(IPlayer player, IPlayer target, string reason)
		{
			Player = (Core.Player)player;
			Target = (Core.Player)target;
			Reason = reason;
		}

		/// <summary>
		/// Gets the player who is issuing the report.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the player being reported.
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Get or set report reason.
		/// </summary>
		public string Reason { get; set; }
	}
}