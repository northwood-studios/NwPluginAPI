using PlayerRoles;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerEscapeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerEscape;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public RoleTypeId NewRole { get; set; }

		public PlayerEscapeEvent(ReferenceHub hub, RoleTypeId newRole)
		{
			Player = Player.Get(hub);
			NewRole = newRole;
		}

		PlayerEscapeEvent() { }
	}
}
