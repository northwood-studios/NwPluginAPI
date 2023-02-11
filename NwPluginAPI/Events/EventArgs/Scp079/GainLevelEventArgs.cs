using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079LevelUpTier"/>.
	/// </summary>
	public class GainLevelEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="GainLevelEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="newLevel"></param>
		public GainLevelEventArgs(IPlayer scp079, int newLevel)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			NewLevel = newLevel;
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
		/// Get or set SCP-079 new tier level.
		/// </summary>
		public int NewLevel { get; set; }
	}
}