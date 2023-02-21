using PlayerRoles;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerEscape"/>.
	/// </summary>
	public class EscapingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DyingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="newRole"></param>
		public EscapingEventArgs(IPlayer player, RoleTypeId newRole)
		{
			Player = (Core.Player)player;
			NewRole = newRole;
		}

		/// <summary>
		/// Gets the player who's is escaping.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get or set new <see cref="RoleTypeId"/> for player.
		/// </summary>
		public RoleTypeId NewRole { get; set; }
	}
}