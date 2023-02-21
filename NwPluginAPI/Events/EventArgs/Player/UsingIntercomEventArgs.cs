using PlayerRoles.Voice;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information while a player is using the intercom.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerUsingIntercom"/>.
	/// </remarks>
	/// </summary>
	public class UsingIntercomEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingIntercomEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="state"></param>
		public UsingIntercomEventArgs(IPlayer player, IntercomState state)
		{
			Player = (Core.Player)player;
			IntercomState = state;
		}

		/// <summary>
		/// Gets the player using the intercom.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get or set the intercom state.
		/// </summary>
		public IntercomState IntercomState { get; set; }
	}
}