using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp096
{
	public class ChangeStateEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChangeStateEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		/// <param name="state">New SCP-096 rage state.</param>
		public ChangeStateEventArgs(IPlayer player, Scp096RageState state)
		{
			Player = (Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
			RageState = state;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets <see cref="Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Gets SCP-096 <see cref="Scp096RageState"/>
		/// </summary>
		public Scp096RageState RageState { get; }
	}
}