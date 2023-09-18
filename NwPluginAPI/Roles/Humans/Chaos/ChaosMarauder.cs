using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Chaos
{
	public class ChaosMarauder<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosMarauder(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
