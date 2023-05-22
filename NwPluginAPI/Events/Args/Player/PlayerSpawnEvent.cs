using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerSpawnEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerSpawn;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public RoleTypeId Role { get; }

		public PlayerSpawnEvent(ReferenceHub hub, RoleTypeId role)
		{
			Player = Core.Player.Get(hub);
			Role = role;
		}

		PlayerSpawnEvent() { }
	}
}
