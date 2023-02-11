using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079CancelRoomLockdown"/>.
	/// </summary>
	public class CancelsRoomLockdownEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CancelsRoomLockdownEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="room"></param>
		public CancelsRoomLockdownEventArgs(IPlayer scp079, FacilityRoom room)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Room = room;
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
		/// Gets <see cref="FacilityRoom"/> in which the lock was cancelled.
		/// </summary>
		public FacilityRoom Room { get; }
	}
}