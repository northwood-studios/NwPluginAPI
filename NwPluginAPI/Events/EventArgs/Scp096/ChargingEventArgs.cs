using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp096
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp096Charging"/>.
	/// </summary>
	public class ChargingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChargingEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		public ChargingEventArgs(IPlayer player, float cooldown)
		{
			Player = (Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
			Cooldown = cooldown;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp096.Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		public float Cooldown { get; set; }
	}
}