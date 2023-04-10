using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class NtfPrivate<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfPrivate(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
