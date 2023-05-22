using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp106
{
	public class Scp106StalkingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp106Stalking;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public bool Activated { get; }

		public Scp106StalkingEvent(ReferenceHub hub, bool activated)
		{
			Player = Core.Player.Get(hub);
			Activated = activated;
		}

		Scp106StalkingEvent() { }
	}
}
