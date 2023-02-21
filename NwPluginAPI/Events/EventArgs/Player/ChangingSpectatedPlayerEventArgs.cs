using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerChangeSpectator"/>.
	/// </summary>
	public class ChangingSpectatedPlayerEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChangingSpectatedPlayerEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="oldTarget"></param>
		/// <param name="newTarget"></param>
		public ChangingSpectatedPlayerEventArgs(IPlayer player, IPlayer oldTarget, IPlayer newTarget)
		{
			Player = (Core.Player)player;
			OldTarget = (Core.Player)oldTarget;
			NewTarget = (Core.Player)newTarget;
		}

		/// <summary>
		/// Gets the player that is changing spectated player.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the player that was spectated.
		/// </summary>
		public Core.Player OldTarget { get; }

		/// <summary>
		/// Get or set the player who's is going to be spectated.
		/// </summary>
		public Core.Player NewTarget { get; set; }
	}
}