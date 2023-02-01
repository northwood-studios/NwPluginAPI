using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp096
{
	public class StartCryingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="StartCryingEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing.</param>
		public StartCryingEventArgs(IPlayer player)
		{
			Player = (Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets <see cref="Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }
	}
}