using PluginAPI.Enums;

namespace PluginAPI.Events
{
	public class MapGeneratedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.MapGenerated;
	}
}
