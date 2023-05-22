using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerEscapeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerEscape;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public RoleTypeId NewRole { get; set; }

		public PlayerEscapeEvent(ReferenceHub hub, RoleTypeId newRole)
		{
			Player = Core.Player.Get(hub);
			NewRole = newRole;
		}

		PlayerEscapeEvent() { }
	}
}
