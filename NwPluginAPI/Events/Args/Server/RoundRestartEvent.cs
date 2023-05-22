using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Server
{
	public class RoundRestartEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RoundRestart;
	}
}
