using Interactables.Interobjects;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp096
{
	public class Scp096PryingGateEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096PryingGate;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public PryableDoor GateDoor { get; }

		public Scp096PryingGateEvent(ReferenceHub hub, PryableDoor door)
		{
			Player = Player.Get(hub);
			GateDoor = door;
		}

		Scp096PryingGateEvent() { }
	}
}
