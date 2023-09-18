using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Ntf
{
	public class NtfCaptain<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfCaptain(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
