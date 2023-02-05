using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Doors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079LockDoor"/>.
	/// </summary>
	public class LockingDownDoorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="LockingDownDoorEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="door"></param>
		/// <param name="energyCost"></param>
		public LockingDownDoorEventArgs(IPlayer scp079, FacilityDoor door, float energyCost)
		{
			Player = (Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Door = door;
			EnergyCost = energyCost;
		}

		/// <summary>
		/// Gets player playing SCP-079.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp079.Scp079Role"/> instance.
		/// </summary>
		public Scp079Role Scp079Role { get; }

		/// <summary>
		/// Gets <see cref="FacilityDoor"/> that SCP-079 is locking.
		/// </summary>
		public FacilityDoor Door { get; }

		/// <summary>
		/// Get or set SCP-079 energy cost.
		/// </summary>
		public float EnergyCost { get; set; }
	}
}