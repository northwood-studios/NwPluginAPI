using System.Numerics;
using PlayerRoles.PlayableScps.Scp106;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp106
{
	/// <summary>
	/// Contains all information before SCP-106 used its hunter atlas ability.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp106UsingHunterAtlas"/>.
	/// </remarks>
	/// </summary>
	public class TeleportingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TeleportingEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		/// <param name="teleport">The position where SCP-106 is about to be teleported.</param>
		public TeleportingEventArgs(IPlayer player, Vector3 teleport)
		{
			Player = (Core.Player)player;
			Scp106Role = Player.RoleBase as Scp106Role;
			Position = teleport;
		}

		/// <summary>
		/// Gets player playing SCP-106.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp106.Scp106Role"/> instance.
		/// </summary>
		public Scp106Role Scp106Role { get; }

		/// <summary>
		/// Gets or set teleport position.
		/// </summary>
		public Vector3 Position { get; set; }
	}
}