using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class FacilityGuard<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public FacilityGuard(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
