using PlayerRoles.PlayableScps.Scp173;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp173
{
	/// <summary>
	/// Contains all the information before an SCP-173 attempts to activate or deactivate its breakneck speeds ability.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp173BreakneckSpeeds"/>.
	/// </remarks>
	/// </summary>
	public class UsingBreakneckSpeedsEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingBreakneckSpeedsEventArgs"/>.
		/// </summary>
		/// <param name="scp173">The player due to this event is executing</param>
		/// <param name="activated">the value indicating whether at the moment of executing the event the ability is being activated or deactivated.</param>
		public UsingBreakneckSpeedsEventArgs(IPlayer scp173, bool activated, float cooldown)
		{
			Player = (Core.Player)scp173;
			Scp173Role = Player.RoleBase as Scp173Role;
			IsActivated = activated;
			Cooldown = cooldown;
		}

		/// <summary>
		/// Gets player playing SCP-173.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		///  Gets <see cref="Scp173Role"/> instance.
		/// </summary>
		public Scp173Role Scp173Role { get; }

		/// <summary>
		/// Gets a value indicating whether the ability is activated.
		/// </summary>
		public bool IsActivated { get; }

		/// <summary>
		/// The cooldown of this ability when disabled.
		/// </summary>
		public float Cooldown { get; set; }
	}
}