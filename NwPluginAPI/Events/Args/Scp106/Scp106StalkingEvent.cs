using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp106
{
	public class Scp106StalkingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp106Stalking;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public bool Activated { get; }

		public Scp106StalkingEvent(ReferenceHub hub, bool activated)
		{
			Player = Player.Get(hub);
			Activated = activated;
		}

		Scp106StalkingEvent() { }
	}
}
