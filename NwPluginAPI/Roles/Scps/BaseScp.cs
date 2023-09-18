using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Scps
{
	public class BaseScp<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public BaseScp(PlayerRoleBase role) : base(role) { }
	}
}
