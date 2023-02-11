using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079BlackoutRoom"/>.
	/// </summary>
	public class BlackoutRoomEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="BlackoutRoomEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="room"></param>
		/// <param name="energyCost"></param>
		/// <param name="cooldown"></param>
		public BlackoutRoomEventArgs(IPlayer scp079, FacilityRoom room, int energyCost, float cooldown)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Room = room;
			EnergyCost = energyCost;
			Cooldown = cooldown;
		}

		/// <summary>
		/// Gets player playing SCP-079.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp079.Scp079Role"/> instance.
		/// </summary>
		public Scp079Role Scp079Role { get; }

		/// <summary>
		/// Gets the room where the blackout is about to occur.
		/// </summary>
		public FacilityRoom Room { get; }

		/// <summary>
		/// Get or set the cost of energy.
		/// </summary>
		public int EnergyCost { get; set; }

		/// <summary>
		/// Get or set the cooldown of this ability.
		/// </summary>
		public float Cooldown { get; set; }
	}
}