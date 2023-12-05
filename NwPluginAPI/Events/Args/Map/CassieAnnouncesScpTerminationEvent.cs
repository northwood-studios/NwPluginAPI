using PlayerStatsSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class CassieAnnouncesScpTerminationEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.CassieAnnouncesScpTermination;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }
		[EventArgument]
		public string Announcement { get; set; }

		public CassieAnnouncesScpTerminationEvent(ReferenceHub hub, DamageHandlerBase handler, string announcement)
		{
			Player = Player.Get(hub);
			DamageHandler = handler;
			Announcement = announcement;
		}

		CassieAnnouncesScpTerminationEvent() { }
	}
}
