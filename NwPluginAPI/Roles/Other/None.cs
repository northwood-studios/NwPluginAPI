using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class None<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public None(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
