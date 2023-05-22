using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using MapGeneration;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079BlackoutZoneEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079BlackoutZone;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public FacilityZone Zone { get; }

		public Scp079BlackoutZoneEvent(ReferenceHub hub, FacilityZone zone)
		{
			Player = Core.Player.Get(hub);
			Zone = zone;
		}

		Scp079BlackoutZoneEvent() { }
	}
}
