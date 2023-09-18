using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerJoinedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerJoined;
		[EventArgument]
		public Core.Player Player { get; }

		public PlayerJoinedEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		PlayerJoinedEvent() { }
	}
}
