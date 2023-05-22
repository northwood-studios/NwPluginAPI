using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans
{
	public class Tutorial<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public Tutorial(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
