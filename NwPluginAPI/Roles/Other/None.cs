using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Other
{
	public class None<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public None(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
