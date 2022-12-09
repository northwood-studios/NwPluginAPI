using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class BaseScp<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public BaseScp(PlayerRoleBase role) : base(role) { }
	}
}
