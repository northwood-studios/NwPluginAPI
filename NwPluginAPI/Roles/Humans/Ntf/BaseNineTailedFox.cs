using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class BaseNineTailedFox<TPlayer> : BaseHuman<TPlayer> where TPlayer : Player
	{
		public BaseNineTailedFox(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
