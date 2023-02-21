using CommandSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerKicked"/>.
	/// </summary>
	public class KickingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="KickingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="issuer"></param>
		/// <param name="reason"></param>
		public KickingEventArgs(IPlayer player, ICommandSender issuer, string reason)
		{
			Player = (Core.Player)player;
			Issuer = Core.Player.Get(issuer);
			Reason = reason;
		}

		public Core.Player Player { get; }

		public Core.Player Issuer { get; }

		public string Reason { get; set; }
	}
}