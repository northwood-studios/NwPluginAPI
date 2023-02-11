using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp049StartResurrectingBody"/>.
	/// </summary>
	public class StartingResurrectionEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="StartingResurrectionEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="target"></param>
		/// <param name="basicRagdoll"></param>
		/// <param name="canRevive"></param>
		public StartingResurrectionEventArgs(IPlayer scp049, IPlayer target, BasicRagdoll basicRagdoll, bool canRevive)
		{
			Player = (Core.Player)scp049;
			Scp049Role = Player.RoleBase as Scp049Role;
			Target = (Core.Player)target;
			Ragdoll = basicRagdoll;
			CanRevive = canRevive;
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
		/// Gets player target.
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Gets target <see cref="BasicRagdoll"/>.
		/// </summary>
		public BasicRagdoll Ragdoll { get; }

		/// <summary>
		/// Get or set if SCP-049 can revive this player.
		/// </summary>
		public bool CanRevive { get; set; }
	}
}