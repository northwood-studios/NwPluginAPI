using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Chaos
{
	public class ChaosConscript<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosConscript(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
