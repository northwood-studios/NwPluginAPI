using CommandSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerBanned"/>.
	/// </summary>
	public class BanningEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="BanningEventArgs"/>.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="issuer"></param>
		/// <param name="reason"></param>
		/// <param name="duration"></param>
		public BanningEventArgs(IPlayer target, ICommandSender issuer, string reason, long duration)
		{
			Target = (Core.Player)target;
			Issuer = Core.Player.Get(issuer);
			Reason = reason;
			Duration = duration;
		}

		/// <summary>
		/// Gets the player who is being banned
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Gets the player who did the ban
		/// </summary>
		public Core.Player Issuer { get; }

		/// <summary>
		/// Get or set the reason for the ban.
		/// </summary>
		public string Reason { get; set; }

		/// <summary>
		/// Get or set the duration of the ban.
		/// </summary>
		public long Duration { get; set; }
	}
}