using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Roles.Humans;

namespace PluginAPI.Roles.Humans.Chaos
{
	public class BaseChaos<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public BaseChaos(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
