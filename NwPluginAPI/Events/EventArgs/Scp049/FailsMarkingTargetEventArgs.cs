using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// Create new event for this.
	/// </summary>
	public class FailsMarkingTargetEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="FailsMarkingTargetEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="cooldown"></param>
		public FailsMarkingTargetEventArgs(IPlayer scp049, float cooldown)
		{
			Player = (Core.Player)scp049;
			Scp049Role = Player.RoleBase as Scp049Role;
			Cooldown = cooldown;
		}

		/// <summary>
		/// Gets player playing SCP-049.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp049.Scp049Role"/> instance.
		/// </summary>
		public Scp049Role Scp049Role { get; }

		/// <summary>
		/// Get or set the cooldown for missing the mark.
		/// </summary>
		public float Cooldown { get; set; }
	}
}