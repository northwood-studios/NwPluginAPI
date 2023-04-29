using PlayerRoles;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerSpawnEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerSpawn;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public RoleTypeId Role { get; }

		public PlayerSpawnEvent(ReferenceHub hub, RoleTypeId role)
		{
			Player = Player.Get(hub);
			Role = role;
		}

		PlayerSpawnEvent() { }
	}
}
