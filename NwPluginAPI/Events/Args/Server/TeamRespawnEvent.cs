using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Respawning;
using System.Collections.Generic;

namespace PluginAPI.Events.Args.Server
{
	public class TeamRespawnEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.TeamRespawn;
		[EventArgument]
		public SpawnableTeamType Team { get; set; }
		[EventArgument]
		public List<Core.Player> Players { get; set; } = new();
		[EventArgument]
		public int NextWaveMaxSize { get; set; }

		public TeamRespawnEvent(SpawnableTeamType team, List<ReferenceHub> spectators)
		{
			Team = team;

			foreach (var spectator in spectators)
			{
				if (Core.Player.TryGet(spectator, out Core.Player plr))
					Players.Add(plr);
			}
		}

		TeamRespawnEvent() { }
	}
}
