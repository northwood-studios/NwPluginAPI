using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079BlackoutZone"/>.
	/// </summary>
	public class BlackoutZoneEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="BlackoutZoneEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="zone"></param>
		/// <param name="energyCost"></param>
		/// <param name="cooldown"></param>
		public BlackoutZoneEventArgs(IPlayer scp079, FacilityZone zone, int energyCost, float cooldown)
		{
			Player = (Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Zone = zone;
			EnergyCost = energyCost;
			Cooldown = cooldown;
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
		/// Get or set the <see cref="FacilityZone"/> where blackout occurs.
		/// </summary>
		public FacilityZone Zone { get; set; }

		/// <summary>
		/// Get or set SCP-079 energy cost.
		/// </summary>
		public int EnergyCost { get; set; }

		/// <summary>
		/// Get or set SCP-079 cooldown.
		/// </summary>
		public float Cooldown { get; set; }
	}
}