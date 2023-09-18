using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Ntf
{
	public class NtfPrivate<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfPrivate(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
