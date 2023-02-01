using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Doors;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp096
{
	public class PryingGateEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PryingGateEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing.</param>
		/// <param name="door">The door which the SCP-096 is forcing its way in.</param>
		public PryingGateEventArgs(IPlayer player, FacilityGate door)
		{
			Player = (Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
			GateDoor = door;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets <see cref="Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Gets the <see cref="FacilityGate"/> that the SCP-096 is forcing.
		/// </summary>
		public FacilityGate GateDoor { get; }
	}
}