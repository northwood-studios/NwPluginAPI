using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class CustomRole<TPlayer> : BaseRole<TPlayer> where TPlayer : Player
	{
		public CustomRole(PlayerRoleBase roleBase) : base(roleBase)
		{
		}
	}
}
