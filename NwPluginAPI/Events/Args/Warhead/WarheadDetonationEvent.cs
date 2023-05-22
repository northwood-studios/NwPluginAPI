using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Warhead
{
	public class WarheadDetonationEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.WarheadDetonation;
	}
}
