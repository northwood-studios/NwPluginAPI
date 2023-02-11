using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp049ResurrectBody "/>.
	/// </summary>
	public class ResurrectBodyEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ResurrectBodyEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="scp0492"></param>
		/// <param name="ragdoll"></param>
		public ResurrectBodyEventArgs(IPlayer scp049, IPlayer scp0492, BasicRagdoll ragdoll, float humeShieldGained)
		{
			Player = (Core.Player)scp049;
			Scp049Role = Player.RoleBase as Scp049Role;
			Target = (Core.Player)scp0492;
			Ragdoll = ragdoll;
			HumeShieldGained = humeShieldGained;
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
		/// Gets player revived.
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Gets target ragdoll.
		/// </summary>
		public BasicRagdoll Ragdoll { get; }

		/// <summary>
		/// Get or set Hume shield gained for revive.
		/// </summary>
		public float HumeShieldGained { get; set; }
	}
}