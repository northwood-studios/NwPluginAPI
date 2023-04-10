using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class Scientist<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public Scientist(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
