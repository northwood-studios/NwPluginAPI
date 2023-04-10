using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Roles;
using PluginAPI.Enums;
using TemplatePlugin.Factory;

namespace TemplatePlugin.Roles
{
	[PluginRole(RoleRegisterType.Override)]
	public class CustomScp049 : Scp049<MyPlayer>
	{
		public CustomScp049(PlayerRoleBase role) : base(role) { }

		public override void OnUpdate()
		{
			if (Player.Health < 100f)
				Player.Health -= 0.001f;
		}

		public override bool InfectPlayer(MyPlayer target)
		{
			target.Ban("Bonk", 30);
			return false;
		}
	}
}
