using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class ChaosConscript<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosConscript(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
