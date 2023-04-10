using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class Scp173<TPlayer> : BaseScp<TPlayer> where TPlayer : Player
	{
		public Scp173(PlayerRoleBase role) : base(role) { }
	}
}
