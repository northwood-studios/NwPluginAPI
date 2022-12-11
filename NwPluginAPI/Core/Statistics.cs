namespace PluginAPI.Core
{
	using System;
	using GameCore;
	using RoundRestarting;
	using UnityEngine;
	using static RoundSummary;

	/// <summary>
	/// Statistics of current server session.
	/// </summary>
	public static class Statistics
	{
		/// <summary>
		/// Gets the total amount of time a player connected to the server successfully.
		/// </summary>
		public static int TotalConnectedPlayers { get; internal set; }

		/// <summary>
		/// Gets the total amount of time a player's connecting to the server was rejected.
		/// </summary>
		public static int TotalRejectedConnections { get; internal set; }

		/// <summary>
		/// Information about timestamp and amount of peak players.
		/// </summary>
		public static Peak PeakPlayers = new Peak(0, DateTime.Now);

		/// <summary>
		/// The amount of times the server restarted round in this session.
		/// </summary>
		public static int TotalRoundrestarts => RoundRestart.UptimeRounds;

		/// <summary>
		/// Information about fastest round.
		/// </summary>
		public static FastestRound FastestEndedRound = new FastestRound(LeadingTeam.FacilityForces, TimeSpan.Zero, DateTime.Now);

		/// <summary>
		/// Statistics related to current round.
		/// </summary>
		public static Round CurrentRound = new Round();

		/// <summary>
		/// Represents a fastest round.
		/// </summary>
		public class FastestRound
		{
			public FastestRound(LeadingTeam leadingTeam, TimeSpan duration, DateTime timestamp)
			{
				LeadingTeam = leadingTeam;
				Duration = duration;
				Timestamp = timestamp;
			}

			public LeadingTeam LeadingTeam { get; private set; } = LeadingTeam.Draw;
			public TimeSpan Duration { get; private set; }
			public DateTime Timestamp { get; private set; } = DateTime.Now;
		}

		/// <summary>
		/// Represents a player count peak.
		/// </summary>
		public class Peak
		{
			public Peak(int total, DateTime timestamp)
			{
				Total = total;
				Timestamp = timestamp;
			}

			public int Total { get; private set; }
			public DateTime Timestamp { get; private set; } = DateTime.Now;
		}

		/// <summary>
		/// Represents a round.
		/// </summary>
		public class Round
		{
			/// <summary>
			/// Gets the duration of the current round.
			/// </summary>
			public static TimeSpan Duration => RoundStart.RoundLength;

			/// <summary>
			/// Gets the current round's starting timestamp.
			/// </summary>
			public DateTime StartTimestamp => DateTime.Now - Duration;

			/// <summary>
			/// Gets the total amount of players deaths.
			/// </summary>
			public int TotalKilledPlayers => Kills;

			public int ClassDStart => RoundSummary.singleton.classlistStart.class_ds;
			public int ClassDDead => Mathf.Clamp(ClassDStart - (ClassDAlive + ClassDEscaped), 0, int.MaxValue);

			/// <summary>
			/// Gets the total amount Class-Ds who have escaped.
			/// </summary>
			public int ClassDEscaped => EscapedClassD;
			public int ClassDAlive { get; set; }
			public int ScientistsStart => RoundSummary.singleton.classlistStart.scientists;
			public int ScientistsDead => Mathf.Clamp(ScientistsStart -  (ScientistsAlive + ScientistsEscaped), 0, int.MaxValue);

			/// <summary>
			/// Gets the total amount Scientists who have escaped.
			/// </summary>
			public int ScientistsEscaped => EscapedScientists;
			public int ScientistsAlive { get; set; }
			public int ChaosInsurgencyStart => RoundSummary.singleton.classlistStart.chaos_insurgents;
			public int ChaosInsurgencyDead => Mathf.Clamp(ChaosInsurgencyStart - ChaosInsurgencyAlive, 0, int.MaxValue);
			public int ChaosInsurgencyAlive { get; set; }
			public int MtfAndGuardsStart => RoundSummary.singleton.classlistStart.mtf_and_guards;
			public int MtfAndGuardsDead => Mathf.Clamp(MtfAndGuardsAlive - MtfAndGuardsStart, 0, int.MaxValue);
			public int MtfAndGuardsAlive { get; set; }
			public int ScpsStart => RoundSummary.singleton.classlistStart.scps_except_zombies;
			public int ScpsDead => Mathf.Clamp(ScpsStart - ScpsAlive, 0, int.MaxValue);

			/// <summary>
			/// Gets the total amount of kills made by SCPs.
			/// </summary>
			public int TotalScpKills => KilledBySCPs;

			/// <summary>
			/// Gets the total amount of SCPs alive.
			/// </summary>
			public int ScpsAlive { get; set; }
			public int ZombiesAlive { get; set; }

			/// <summary>
			/// Gets the total amount Scp049-2s created.
			/// </summary>
			public int ZombiesChanged => ChangedIntoZombies;
			public int WarheadKills { get; set; }
		}
	}
}
