using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerJoinedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerJoined;
		[EventArgument]
		public Player Player { get; }

		public PlayerJoinedEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		PlayerJoinedEvent() { }
	}
}
