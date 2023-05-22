using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans
{
	public class ClassD<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public ClassD(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
