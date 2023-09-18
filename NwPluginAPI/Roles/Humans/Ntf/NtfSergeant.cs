using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Ntf
{
	public class NtfSergeant<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfSergeant(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
