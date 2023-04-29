using PluginAPI.Enums;

namespace PluginAPI.Events
{
	public class LczDecontaminationStartEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.LczDecontaminationStart;
	}
}
