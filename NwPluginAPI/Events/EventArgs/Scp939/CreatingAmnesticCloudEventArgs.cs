using PlayerRoles.PlayableScps.Scp939;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp939
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp939CreateAmnesticCloud "/>.
	/// </summary>
	public class CreatingAmnesticCloudEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CreatingAmnesticCloudEventArgs"/>.
		/// </summary>
		/// <param name="scp939">The player due to this event is executing.</param>
		public CreatingAmnesticCloudEventArgs(IPlayer scp939)
		{
			Player = (Core.Player)scp939;
			Scp939Role = Player.RoleBase as Scp939Role;
		}

		/// <summary>
		/// Gets player playing SCP-939.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp939.Scp939Role"/> instance.
		/// </summary>
		public Scp939Role Scp939Role { get; }
	}
}