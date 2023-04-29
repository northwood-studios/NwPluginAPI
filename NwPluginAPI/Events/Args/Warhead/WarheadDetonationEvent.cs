using PluginAPI.Enums;

namespace PluginAPI.Events
{
	public class WarheadDetonationEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.WarheadDetonation;
	}
}
