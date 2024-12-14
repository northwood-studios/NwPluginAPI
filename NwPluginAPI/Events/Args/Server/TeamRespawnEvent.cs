using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using System.Collections.Generic;
using PlayerRoles;

namespace PluginAPI.Events.Args.Server
{
	public class TeamRespawnEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.TeamRespawn;
		[EventArgument]
		public Faction Team { get; set; }
		[EventArgument]
		public List<Player> Players { get; set; } = new List<Player>();
		[EventArgument]
		public int NextWaveMaxSize { get; set; }

		public TeamRespawnEvent(Faction team, List<ReferenceHub> spectators)
		{
			Team = team;

			foreach(var spectator in spectators)
			{
				if (Player.TryGet(spectator, out Player plr))
					Players.Add(plr);
			}
		}

		TeamRespawnEvent() { }
	}
}
