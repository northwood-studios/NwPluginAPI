using PluginAPI.Enums;
using Respawning;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.TeamRespawnSelected"/>.
	/// </summary>
	public class TeamRespawnSelectedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TeamRespawnSelectedEventArgs"/>.
		/// </summary>
		/// <param name="teamType"></param>
		public TeamRespawnSelectedEventArgs(SpawnableTeamType teamType)
		{
			NextSpawnableTeam = teamType;
		}

		/// <summary>
		/// Get or set next team to spawn.
		/// </summary>
		public SpawnableTeamType NextSpawnableTeam { get; set; }
	}
}