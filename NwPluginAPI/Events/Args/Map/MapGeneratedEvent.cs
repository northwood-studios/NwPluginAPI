using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Map
{
	public class MapGeneratedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.MapGenerated;
	}
}
