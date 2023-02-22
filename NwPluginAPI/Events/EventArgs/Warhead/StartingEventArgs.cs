using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Warhead
{
	/// <summary>
	/// Contains all the information at the time of starting the warhead
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.WarheadStart"/>.
	/// </remarks>
	/// </summary>
	public class StartingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="StartingEventArgs"/>.
		/// </summary>
		/// <param name="isAutomatic"></param>
		/// <param name="player"></param>
		/// <param name="isResumed"></param>
		public StartingEventArgs(bool isAutomatic, IPlayer player, bool isResumed)
		{
			Player = (Core.Player)player;
			IsAutomatic = isAutomatic;
			IsResumed = isResumed;
		}

		/// <summary>
		/// Gets the player who's going to start the warhead.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get a value indicating if the warhead was activated automatically
		/// </summary>
		public bool IsAutomatic { get; }

		/// <summary>
		/// Gets a value indicating if warhead should be resume the countdown.
		/// </summary>
		public bool IsResumed { get; }
	}
}