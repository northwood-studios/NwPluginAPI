using PlayerRoles.PlayableScps.Scp173;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp173
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp173CreateTantrum"/>.
	/// </summary>
	public class PlacingTantrumEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PlacingTantrumEventArgs"/>.
		/// </summary>
		/// <param name="scp173">The player due to this event is executing</param>
		public PlacingTantrumEventArgs(IPlayer scp173)
		{
			Player = (Player)scp173;
			Scp173Role = Player.RoleBase as Scp173Role;
			if (Scp173Role.SubroutineModule.TryGetSubroutine<Scp173TantrumAbility>(out var ability))
				TantrumAbility = ability;
		}

		/// <summary>
		/// Gets player playing SCP-173.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		///  Gets <see cref="Scp173Role"/> instance.
		/// </summary>
		public Scp173Role Scp173Role { get; }

		/// <summary>
		///  Gets <see cref="Scp173TantrumAbility"/> instance.
		/// </summary>
		public Scp173TantrumAbility TantrumAbility { get; }
	}
}