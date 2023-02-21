using PlayerRoles;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerSpawn"/>.
	/// </summary>
	public class SpawningEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="SpawningEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="role"></param>
		public SpawningEventArgs(IPlayer player, RoleTypeId role)
		{
			Player = (Core.Player)player;
			RoleBase = Player.RoleBase;
			RoleType = role;
		}

		/// <summary>
		/// Gets the player spawning.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets <see cref="PlayerRoleBase"/> of the player role.
		/// </summary>
		public PlayerRoleBase RoleBase { get; }

		/// <summary>
		/// Gets <see cref="RoleTypeId"/> spawning.
		/// </summary>
		public RoleTypeId RoleType { get; }
	}
}