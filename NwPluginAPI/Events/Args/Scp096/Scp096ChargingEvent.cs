using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp096ChargingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096Charging;
		[EventArgument]
		public Player Player { get; }

		public Scp096ChargingEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		Scp096ChargingEvent() { }
	}
}
