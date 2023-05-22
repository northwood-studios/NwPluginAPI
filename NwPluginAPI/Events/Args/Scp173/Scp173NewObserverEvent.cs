using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp173
{
	public class Scp173NewObserverEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173NewObserver;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }

		public Scp173NewObserverEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
		}

		Scp173NewObserverEvent() { }
	}
}
