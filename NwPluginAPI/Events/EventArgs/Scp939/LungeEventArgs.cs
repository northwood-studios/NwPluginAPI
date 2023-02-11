using PlayerRoles.PlayableScps.Scp939;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp939
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp939Lunge"/>.
	/// </summary>
	public class LungeEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="Scp939AttackEventArgs"/>.
		/// </summary>
		/// <param name="scp939"></param>
		/// <param name="state"></param>
		public LungeEventArgs(IPlayer scp939, Scp939LungeState state)
		{
			Player = (Core.Player)scp939;
			Scp939Role = Player.RoleBase as Scp939Role;
			LungeState = state;
		}

		/// <summary>
		/// Gets player playing SCP-939.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp939.Scp939Role"/> instance.
		/// </summary>
		public Scp939Role Scp939Role { get; }

		/// <summary>
		/// Gets or set SCP-939 lunge state.
		/// </summary>
		public Scp939LungeState LungeState { get; set; }
	}
}