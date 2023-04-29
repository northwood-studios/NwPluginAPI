using PluginAPI.Enums;

namespace PluginAPI.Events
{
	public class RoundStartEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RoundStart;
	}
}
