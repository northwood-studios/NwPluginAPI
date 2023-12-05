using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class ChaosRepressor<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosRepressor(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
