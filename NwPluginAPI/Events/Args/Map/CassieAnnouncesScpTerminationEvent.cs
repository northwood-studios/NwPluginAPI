using PlayerStatsSystem;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Map
{
	public class CassieAnnouncesScpTerminationEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.CassieAnnouncesScpTermination;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }
		[EventArgument]
		public string Announcement { get; set; }

		public CassieAnnouncesScpTerminationEvent(ReferenceHub hub, DamageHandlerBase handler, string announcement)
		{
			Player = Core.Player.Get(hub);
			DamageHandler = handler;
			Announcement = announcement;
		}

		CassieAnnouncesScpTerminationEvent() { }
	}
}
