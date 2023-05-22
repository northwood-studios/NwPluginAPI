using PlayerRoles;
using PluginAPI.Core;

namespace PluginAPI.Roles.Humans.Ntf
{
	public class NtfSpecialist<TPlayer> : BaseNineTailedFox<TPlayer> where TPlayer : Player
	{
		public NtfSpecialist(PlayerRoleBase roleBase) : base(roleBase) { }
	}
}
