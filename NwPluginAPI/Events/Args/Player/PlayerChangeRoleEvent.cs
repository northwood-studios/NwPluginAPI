using PlayerRoles;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerChangeRoleEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerChangeRole;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public PlayerRoleBase OldRole { get; }
		[EventArgument]
		public RoleTypeId NewRole { get; set; }
		[EventArgument]
		public RoleChangeReason ChangeReason { get; }

		public PlayerChangeRoleEvent(ReferenceHub hub, PlayerRoleBase oldRole, RoleTypeId newRole, RoleChangeReason reason)
		{
			Player = Player.Get(hub);
			OldRole = oldRole;
			NewRole = newRole;
			ChangeReason = reason;
		}

		PlayerChangeRoleEvent() { }
	}
}
