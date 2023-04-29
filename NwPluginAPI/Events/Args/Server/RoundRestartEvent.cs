using PluginAPI.Enums;

namespace PluginAPI.Events
{
	public class RoundRestartEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RoundRestart;
	}
}
