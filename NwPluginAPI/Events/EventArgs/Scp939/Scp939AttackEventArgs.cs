using PlayerRoles.PlayableScps.Scp939;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp939
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp939Attack"/>.
	/// </summary>
	public class Scp939AttackEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="Scp939AttackEventArgs"/>.
		/// </summary>
		/// <param name="scp939"></param>
		/// <param name="target"></param>
		public Scp939AttackEventArgs(IPlayer scp939, IDestructible target)
		{
			Player = (Player)scp939;
			Scp939Role = Player.RoleBase as Scp939Role;
			Target = target;
		}

		/// <summary>
		/// Gets player playing SCP-939.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp939.Scp939Role"/> instance.
		/// </summary>
		public Scp939Role Scp939Role { get; }

		/// <summary>
		/// Gets <see cref="IDestructible"/> target.
		/// </summary>
		public IDestructible Target { get; }
	}
}