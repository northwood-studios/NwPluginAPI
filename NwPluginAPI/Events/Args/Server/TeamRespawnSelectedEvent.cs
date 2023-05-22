using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Respawning;

namespace PluginAPI.Events.Args.Server
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
