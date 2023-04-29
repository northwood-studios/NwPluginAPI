using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using MapGeneration;

namespace PluginAPI.Events
{
	public class Scp079BlackoutZoneEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079BlackoutZone;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public FacilityZone Zone { get; }

		public Scp079BlackoutZoneEvent(ReferenceHub hub, FacilityZone zone)
		{
			Player = Player.Get(hub);
			Zone = zone;
		}

		Scp079BlackoutZoneEvent() { }
	}
}
