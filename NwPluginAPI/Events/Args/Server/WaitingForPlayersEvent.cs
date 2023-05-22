using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Server
{
	public class WaitingForPlayersEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.WaitingForPlayers;
	}
}
