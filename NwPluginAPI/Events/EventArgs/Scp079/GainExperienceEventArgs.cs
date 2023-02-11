using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079GainExperience"/>.
	/// </summary>
	public class GainExperienceEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="GainExperienceEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="amount"></param>
		/// <param name="reason"></param>
		public GainExperienceEventArgs(IPlayer scp079, int amount, Scp079HudTranslation reason)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Amount = amount;
			Reason = reason;
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
		/// Get or set the amount of experience earned by the SCP-079.
		/// </summary>
		public int Amount { get; set; }

		/// <summary>
		/// Get or set <see cref="Scp079HudTranslation"/>.
		/// </summary>
		public Scp079HudTranslation Reason { get; set; }
	}
}