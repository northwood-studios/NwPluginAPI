using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp096
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp096ChangeState"/>.
	/// </summary>
	public class ChangeStateEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChangeStateEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		/// <param name="state">New SCP-096 rage state.</param>
		public ChangeStateEventArgs(IPlayer player, Scp096RageState state)
		{
			Player = (Core.Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
			RageState = state;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp096.Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Get or set SCP-096 <see cref="Scp096RageState"/>
		/// </summary>
		public Scp096RageState RageState { get; set; }
	}
}