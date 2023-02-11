using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Doors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079UnlockDoor"/>.
	/// </summary>
	public class CancelsDoorLockdownEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CancelsDoorLockdownEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="door"></param>
		public CancelsDoorLockdownEventArgs(IPlayer scp079, FacilityDoor door)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Door = door;
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
		/// Gets <see cref="FacilityDoor"/> in which the lock was cancelled.
		/// </summary>
		public FacilityDoor Door { get; }
	}
}