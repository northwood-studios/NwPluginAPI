using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Chaos
{
	public class ChaosRepressor<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosRepressor(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
