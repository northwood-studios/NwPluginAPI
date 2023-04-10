using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class ChaosMarauder<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosMarauder(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
