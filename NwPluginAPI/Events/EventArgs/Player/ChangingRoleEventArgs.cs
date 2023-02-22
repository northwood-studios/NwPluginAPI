using PlayerRoles;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerChangeRole"/>.
	/// </summary>
	public class ChangingRoleEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChangedRoleEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="oldRole"></param>
		/// <param name="newRole"></param>
		/// <param name="reason"></param>
		public ChangingRoleEventArgs(IPlayer player, PlayerRoleBase oldRole, RoleTypeId newRole,
			RoleChangeReason reason)
		{
			Player = (Core.Player)player;
			OldRole = oldRole;
			NewRole = newRole;
			Reason = reason;
		}

		/// <summary>
		/// Gets the player changing role
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player old <see cref="PlayerRoleBase"/>.
		/// </summary>
		public PlayerRoleBase OldRole { get; }

		/// <summary>
		/// Get or set player new role type.
		/// </summary>
		public RoleTypeId NewRole { get; set; }

		/// <summary>
		/// Get or set role change reason.
		/// </summary>
		public RoleChangeReason Reason { get; set; }
	}
}