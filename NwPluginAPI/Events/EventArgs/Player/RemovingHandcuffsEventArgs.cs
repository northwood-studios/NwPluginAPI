using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerRemoveHandcuffs"/>.
	/// </summary>
	public class RemovingHandcuffsEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="RemovingHandcuffsEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="target"></param>
		public RemovingHandcuffsEventArgs(IPlayer player, IPlayer target)
		{
			Player = (Core.Player)player;
			Target = (Core.Player)target;
		}

		/// <summary>
		/// Gets the cuffer player.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the target player to be uncuffed.
		/// </summary>
		public Core.Player Target { get; }
	}
}