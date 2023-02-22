using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// Contains all information before SCP-049 loses a player marked for its ability.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp049LosingMarkedPlayer"/>.
	/// </remarks>
	/// </summary>
	public class LoseMarkEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="LoseMarkEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="cooldown"></param>
		public LoseMarkEventArgs(IPlayer scp049, float cooldown)
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
		/// Get or set cooldown on lose the target.
		/// </summary>
		public float Cooldown { get; set; }
	}
}