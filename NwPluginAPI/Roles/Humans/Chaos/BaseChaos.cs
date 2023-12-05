using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class BaseChaos<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public BaseChaos(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
