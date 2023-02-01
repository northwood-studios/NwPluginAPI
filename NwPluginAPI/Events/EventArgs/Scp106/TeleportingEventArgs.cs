using System.Numerics;
using PlayerRoles.PlayableScps.Scp106;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp106
{
	public class TeleportingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TeleportingEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		/// <param name="teleport">The position where SCP-106 is about to be teleported.</param>
		public TeleportingEventArgs(IPlayer player, Vector3 teleport)
		{
			Player = (Player)player;
			Scp106Role = Player.RoleBase as Scp106Role;
		}

		/// <summary>
		/// Gets player playing SCP-106.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets <see cref="Scp106Role"/> instance.
		/// </summary>
		public Scp106Role Scp106Role { get; }

		/// <summary>
		/// Gets or set teleport position.
		/// </summary>
		public Vector3 Position { get; set; }
	}
}