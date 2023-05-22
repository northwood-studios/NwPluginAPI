using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp173
{
	public class Scp173NewObserverEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173NewObserver;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }

		public Scp173NewObserverEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
		}

		Scp173NewObserverEvent() { }
	}
}
