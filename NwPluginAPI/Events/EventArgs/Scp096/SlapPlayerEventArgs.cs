using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp096
{
	/// <summary>
	/// Contains all the information before an SCP-096 hit a player with an attack
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp096SlapPlayer"/>.
	/// </remarks>
	/// </summary>
	public class SlapPlayerEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="SlapPlayerEventArgs"/>.
		/// </summary>
		/// <param name="scp096"></param>
		/// <param name="target"></param>
		/// <param name="isLeftHand"></param>
		/// <param name="damage"></param>
		public SlapPlayerEventArgs(IPlayer scp096, IPlayer target, bool isLeftHand, float damage)
		{
			Player = (Core.Player)scp096;
			Scp096Role = Player.RoleBase as Scp096Role;
			Target = (Core.Player)target;
			IsLeftAttack = isLeftHand;
			Damage = damage;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp096.Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Gets player slapped for SCP-096.
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Gets or set if SCP-096 attacks with left hand.
		/// </summary>
		public bool IsLeftAttack { get; set; }

		/// <summary>
		/// Get or set damage inflicted.
		/// </summary>
		public float Damage { get; set; }
	}
}