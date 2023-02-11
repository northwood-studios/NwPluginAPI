using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// Make new event for this.
	/// </summary>
	public class MarkTargetEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="MarkTargetEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="target"></param>
		/// <param name="duration"></param>
		public MarkTargetEventArgs(IPlayer scp049, IPlayer target, float duration)
		{
			Player = (Core.Player)scp049;
			Scp049Role = Player.RoleBase as Scp049Role;
			Target = (Core.Player)target;
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
		/// Gets player target marked.
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Get or set the duration of the mark.
		/// </summary>
		public float Duration { get; set; }
	}
}