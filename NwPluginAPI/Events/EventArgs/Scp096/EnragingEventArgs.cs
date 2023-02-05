using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp096
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp096Enraging"/>.
	/// </summary>
	public class EnragingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="EnragingEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		/// <param name="initialDuration">The duration of the rage</param>
		public EnragingEventArgs(IPlayer player, float initialDuration)
		{
			Player = (Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
			InitialDuration = initialDuration;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp096.Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Gets or Set duration of the rage
		/// </summary>
		public float InitialDuration { get; set; }
	}
}