using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp096
{
	public class Scp096EnragingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096Enraging;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public float InitialDuration { get; }

		public Scp096EnragingEvent(ReferenceHub hub, float intialDuration)
		{
			Player = Core.Player.Get(hub);
			InitialDuration = intialDuration;
		}

		Scp096EnragingEvent() { }
	}
}
