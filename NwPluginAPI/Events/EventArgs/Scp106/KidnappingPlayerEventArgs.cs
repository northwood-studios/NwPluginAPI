using PlayerRoles.PlayableScps.Scp106;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp106
{
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
		/// Gets <see cref="Scp106Role"/> instance.
		/// </summary>
		public Scp106Role Scp106Role { get; }

		// I had fun thinking of the name of the class.
	}
}