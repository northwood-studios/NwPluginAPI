using PlayerRoles.PlayableScps.Scp049.Zombies;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp0492
{
	/// <summary>
	/// Create new event for this.
	/// </summary>
	public class ConsumeCorpseEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ConsumeCorpseEventArgs"/>.
		/// </summary>
		/// <param name="scp0492"></param>
		/// <param name="ragdoll"></param>
		/// <param name="healAmount"></param>
		public ConsumeCorpseEventArgs(IPlayer scp0492, BasicRagdoll ragdoll, float healAmount)
		{
			Player = (Core.Player)scp0492;
			Scp0492Role = Player.RoleBase as ZombieRole;
			Ragdoll = ragdoll;
			HealAmount = healAmount;
		}

		/// <summary>
		/// Gets player playing SCP-049-2.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp049.Zombies.ZombieRole"/> instance.
		/// </summary>
		public ZombieRole Scp0492Role { get; }

		/// <summary>
		/// Gets <see cref="BasicRagdoll"/> consumed.
		/// </summary>
		public BasicRagdoll Ragdoll { get; }

		/// <summary>
		/// Get or set heal value for consuming a corpse.
		/// </summary>
		public float HealAmount { get; set; }
	}
}