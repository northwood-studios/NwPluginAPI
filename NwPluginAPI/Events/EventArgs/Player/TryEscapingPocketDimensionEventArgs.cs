using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player tries to escape from the pocket dimension
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerExitPocketDimension"/>.</remarks>
	/// </summary>
	public class TryEscapingPocketDimensionEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TryEscapingPocketDimensionEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="isSuccessful"></param>
		public TryEscapingPocketDimensionEventArgs(IPlayer player, bool isSuccessful)
		{
			Player = (Core.Player)player;
			IsSuccessful = isSuccessful;
		}

		/// <summary>
		/// Gets the player trying to escape the pocked dimension.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets a value indicating if the player take the correct door.
		/// </summary>
		public bool IsSuccessful { get; }
	}
}