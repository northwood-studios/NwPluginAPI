using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class NtfSergeant<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfSergeant(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
