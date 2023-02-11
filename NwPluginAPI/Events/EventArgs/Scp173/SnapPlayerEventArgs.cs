using PlayerRoles.PlayableScps.Scp173;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp173
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp173SnapPlayer"/>
	/// </summary>
	public class SnapPlayerNeckEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="SnapPlayerNeckEventArgs"/>.
		/// </summary>
		/// <param name="scp173">The player due to this event is executing.</param>
		/// <param name="target">Player that SCP-173 is attempting to snap its neck.</param>
		public SnapPlayerNeckEventArgs(IPlayer scp173, IPlayer target)
		{
			Player = (Core.Player)scp173;
			Scp173Role = Player.RoleBase as Scp173Role;
			Target = (Core.Player)target;
		}

		/// <summary>
		/// Gets player playing SCP-173.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp173.Scp173Role"/> instance.
		/// </summary>
		public Scp173Role Scp173Role { get; }

		/// <summary>
		/// Get the player that SCP-173 is attempting to snap its neck.
		/// </summary>
		public Core.Player Target { get; }
	}
}