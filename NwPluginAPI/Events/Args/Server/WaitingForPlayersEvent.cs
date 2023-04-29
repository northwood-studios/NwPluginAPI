using PluginAPI.Enums;

namespace PluginAPI.Events
{
	public class WaitingForPlayersEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.WaitingForPlayers;
	}
}
