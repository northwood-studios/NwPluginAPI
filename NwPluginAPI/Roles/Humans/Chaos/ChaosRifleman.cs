using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Chaos
{
	public class ChaosRifleman<TPlayer> : BaseChaos<TPlayer> where TPlayer : Player
	{
		public ChaosRifleman(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
