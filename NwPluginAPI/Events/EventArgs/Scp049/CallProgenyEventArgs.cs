using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// Create a new Event for this licht
	/// </summary>
	public class CallProgenyEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CallProgenyEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="duration"></param>
		public CallProgenyEventArgs(IPlayer scp049, float duration)
		{
			Player = (Core.Player)scp049;
			Scp049Role = Player.RoleBase as Scp049Role;
			Duration = duration;
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
		/// Get or set the duration of the call for all SCP-049-2.
		/// </summary>
		public float Duration { get; set; }
	}
}