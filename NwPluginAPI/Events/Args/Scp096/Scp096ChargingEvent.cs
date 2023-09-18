using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp096
{
	public class Scp096ChargingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096Charging;
		[EventArgument]
		public Core.Player Player { get; }

		public Scp096ChargingEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		Scp096ChargingEvent() { }
	}
}
