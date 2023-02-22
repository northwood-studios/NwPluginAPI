using System.Collections.Generic;
using JetBrains.Annotations;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using Respawning;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.TeamRespawn"/>.
	/// </summary>
	public class TeamRespawningEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TeamRespawningEventArgs"/>.
		/// </summary>
		/// <param name="players"></param>
		/// <param name="waveSize"></param>
		public TeamRespawningEventArgs(List<IPlayer> players, int waveSize, SpawnableTeamType teamType)
		{
			var list = new List<Core.Player>();
			foreach (var player in players)
			{
				list.Add((Core.Player)player);
			}

			Players = list;

			WaveSizes = waveSize;
		}

		/// <summary>
		/// Gets the list of players that are going to be respawned.
		/// </summary>
		public List<Core.Player> Players { get; }

		/// <summary>
		/// Get or set the number of players to be respawned.
		/// </summary>
		public int WaveSizes { get; set; }

		/// <summary>
		/// Gets the team spawning.
		/// </summary>
		public SpawnableTeamType Team { get; }
	}
}