using PlayerRoles;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Server
{
	public class TeamRespawnSelectedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.TeamRespawnSelected;
		[EventArgument]
		public Faction Team { get; }

		public TeamRespawnSelectedEvent(Faction team)
		{
			Team = team;
		}

		TeamRespawnSelectedEvent() { }
	}
}
