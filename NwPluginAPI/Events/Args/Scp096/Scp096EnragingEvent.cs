using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp096EnragingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096Enraging;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public float InitialDuration { get; }

		public Scp096EnragingEvent(ReferenceHub hub, float intialDuration)
		{
			Player = Player.Get(hub);
			InitialDuration = intialDuration;
		}

		Scp096EnragingEvent() { }
	}
}
