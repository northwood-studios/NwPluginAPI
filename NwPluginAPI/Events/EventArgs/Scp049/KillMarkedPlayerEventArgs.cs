using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp049
{
	/// <summary>
	/// Create new event for this.
	/// </summary>
	public class KillMarkedPlayerEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="KillMarkedPlayerEventArgs"/>.
		/// </summary>
		/// <param name="scp049"></param>
		/// <param name="target"></param>
		/// <param name="cooldown"></param>
		public KillMarkedPlayerEventArgs(IPlayer scp049, IPlayer target, float cooldown)
		{
			Player = (Player)scp049;
			Scp049Role = Player.RoleBase as Scp049Role;
			Target = (Player)target;
			Cooldown = cooldown;
		}

		/// <summary>
		/// Gets player playing SCP-049.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp049.Scp049Role"/> instance.
		/// </summary>
		public Scp049Role Scp049Role { get; }

		/// <summary>
		/// Gets player killed for SCP-049.
		/// </summary>
		public Player Target { get; }

		/// <summary>
		/// Get or set mark cooldown.
		/// </summary>
		public float Cooldown { get; set; }
	}
}