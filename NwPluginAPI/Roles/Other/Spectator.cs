using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Other
{
	public class Spectator<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public Spectator(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
