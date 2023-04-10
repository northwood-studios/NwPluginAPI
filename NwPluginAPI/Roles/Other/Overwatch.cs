using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class Overwatch<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public Overwatch(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
