using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace PluginAPI.Events.EventArgs.Scp096
{
	public class ChargingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChargingEventArgs"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		public ChargingEventArgs(IPlayer player)
		{
			Player = (Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;

			if (Scp096Role.SubroutineModule.TryGetSubroutine<Scp096ChargeAbility>(out var ability))
				ChargeAbility = ability;
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
		/// Gets <see cref="Scp096ChargeAbility"/> instance.
		/// </summary>
		public Scp096ChargeAbility ChargeAbility { get; }
	}
}