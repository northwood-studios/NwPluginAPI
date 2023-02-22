using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// Contains all information before SCP-049 marks a player with its ability
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp049MarkingPlayer"/>.
	/// </remarks>
	/// </summary>
	public class MarkingTargetEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="MarkingTargetEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="target"></param>
		/// <param name="duration"></param>
		public MarkingTargetEventArgs(IPlayer scp049, IPlayer target, float duration)
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