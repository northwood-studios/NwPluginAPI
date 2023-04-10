using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class ChaosRifleman<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosRifleman(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
