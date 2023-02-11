using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp096
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp096StartCrying"/>.
	/// </summary>
	public class StartCryingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="StartCryingEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing.</param>
		public StartCryingEventArgs(IPlayer player)
		{
			Player = (Core.Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp096.Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }
	}
}