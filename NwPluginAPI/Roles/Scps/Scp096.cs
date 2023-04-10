using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class Scp096<TPlayer> : BaseScp<TPlayer> where TPlayer : Player
	{
		public Scp096(PlayerRoleBase role) : base(role) { }
	}
}
