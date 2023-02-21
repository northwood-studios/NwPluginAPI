using PlayerStatsSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Map
{
	/// <summary>
	/// Contains all the information before CASSIE announce a SCP termination.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.CassieAnnouncesScpTermination"/>.
	/// </remarks>
	/// </summary>
	public class AnnouncingScpTerminationEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="AnnouncingScpTerminationEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="damage"></param>
		/// <param name="announcement"></param>
		public AnnouncingScpTerminationEventArgs(IPlayer player, DamageHandlerBase damage, string announcement)
		{
			Player = (Core.Player)player;
			DamageHandler = damage;
			Announcement = announcement;
		}

		/// <summary>
		/// Gets the player scp terminated.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the damage handler.
		/// </summary>
		public DamageHandlerBase DamageHandler { get; }

		/// <summary>
		/// Gets or set announcement.
		/// </summary>
		public string Announcement { get; set; }
	}
}