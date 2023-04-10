using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles
{
	public class NtfSpecialist<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfSpecialist(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
