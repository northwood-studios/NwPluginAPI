using JetBrains.Annotations;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Warhead
{
	/// <summary>
	/// Contains all the information at the time of stopping the warhead.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.WarheadStop"/>.
	/// </remarks>
	/// </summary>
	public class StoppingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="StoppingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		public StoppingEventArgs(IPlayer player)
		{
			Player = (Core.Player)player;
		}

		/// <summary>
		/// Gets the player who is stopping the warhead.
		/// </summary>
		[CanBeNull]
		public Core.Player Player { get; }
	}
}