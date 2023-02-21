using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information before a player enters the pocket dimension.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerEnterPocketDimension"/>.</remarks>
	/// </summary>
	public class EnteringPocketDimensionEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="EnteringPocketDimensionEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		public EnteringPocketDimensionEventArgs(IPlayer player)
		{
			Player = (Core.Player)player;
		}

		/// <summary>
		/// Gets the player entering to the pocked dimension.
		/// </summary>
		public Core.Player Player { get; }
	}
}