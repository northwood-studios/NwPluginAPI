using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class Spectator<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public Spectator(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
