using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Respawning;

namespace PluginAPI.Events
{
	public class TeamRespawnSelectedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.TeamRespawnSelected;
		[EventArgument]
		public SpawnableTeamType Team { get; }

		public TeamRespawnSelectedEvent(SpawnableTeamType team)
		{
			Team = team;
		}

		TeamRespawnSelectedEvent() { }
	}
}
