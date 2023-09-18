using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Chaos
{
	public class BaseChaos<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public BaseChaos(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
