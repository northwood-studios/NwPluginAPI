using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans
{
	public class BaseHuman<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public BaseHuman(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
