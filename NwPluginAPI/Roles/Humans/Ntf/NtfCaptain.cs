using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class NtfCaptain<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfCaptain(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
