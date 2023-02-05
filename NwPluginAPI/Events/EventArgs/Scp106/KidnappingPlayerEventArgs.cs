using PlayerRoles.PlayableScps.Scp106;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp106
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp106TeleportPlayer"/>.
	/// </summary>
	public class KidnappingPlayerEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="KidnappingPlayerEventArgs"/>.
		/// </summary>
		/// <param name="scp106">The player due to this event is executing.</param>
		/// <param name="target">Player who will be teleported to the pocket dimension.</param>
		public KidnappingPlayerEventArgs(IPlayer scp106, IPlayer target)
		{
			Player = (Player)scp106;
			Scp106Role = Player.RoleBase as Scp106Role;
			Target = (Player)target;
		}

		/// <summary>
		/// Gets player playing SCP-106.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets kidnapped player.
		/// </summary>
		public Player Target { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp106.Scp106Role"/> instance.
		/// </summary>
		public Scp106Role Scp106Role { get; }

		/// <summary>
		/// Get or set SCP-106 cooldown of this ability.
		/// </summary>
		public float Cooldown { get; set; }

		/// <summary>
		/// Get or set the amount of vigor gained by SCP-106 at kidnapping someone to its pocket dimension.
		/// </summary>
		public float VigorGained { get; set; }

		// I had fun thinking of the name of the class.
	}
}