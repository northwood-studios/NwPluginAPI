using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Server
{
	public class RoundStartEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RoundStart;
	}
}
