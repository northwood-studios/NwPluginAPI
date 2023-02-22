using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// Contains all the information before an SCP-049 uses its ability to call zombies.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp049CallProgeny"/>.
	/// </remarks>
	/// </summary>
	public class CallProgenyEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CallProgenyEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="duration"></param>
		public CallProgenyEventArgs(IPlayer scp049,Scp049CallAbility ability, float duration)
		{
			Player = (Core.Player)scp049;
			Scp049Role = Player.RoleBase as Scp049Role;
			Ability = ability;
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
		/// Gets <see cref="Scp049CallAbility"/> instance.
		/// </summary>
		public Scp049CallAbility Ability { get; }

		/// <summary>
		/// Get or set the duration of the call for all SCP-049-2.
		/// </summary>
		public float Duration { get; set; }
	}
}