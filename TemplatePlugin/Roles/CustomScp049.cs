using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Roles.Scps;
using TemplatePlugin.Factory;

namespace TemplatePlugin.Roles
{
	[PluginRole(RoleRegisterType.Override)]
	public class CustomScp049 : Scp049<MyPlayer>
	{
		public CustomScp049(Scp049Role role) : base(role) { }

		public override void OnUpdate()
		{
			if (Player.Health < 100f)
				Player.Health -= 0.001f;
		}

		public override bool InfectPlayer(MyPlayer target)
		{
			target.Ban("Ban", 30);
			return false;
		}
	}
}
