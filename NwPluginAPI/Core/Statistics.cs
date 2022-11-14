namespace PluginAPI.Core
{
	using System;
	using GameCore;
	using RoundRestarting;
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
		public static Peak PeakPlayers = new Peak();

		/// <summary>
		/// The amount of times the server restarted round in this session.
		/// </summary>
		public static int TotalRoundrestarts => RoundRestart.UptimeRounds;

		/// <summary>
		/// Information about fastest round.
		/// </summary>
		public static FastestRound FastestEndedRound;

		/// <summary>
		/// Statistics related to current round.
		/// </summary>
		public static readonly Round CurrentRound = new Round();

		/// <summary>
		/// Represents a fastest round.
		/// </summary>
		public class FastestRound
		{
			public LeadingTeam LeadingTeam { get; internal set; } = LeadingTeam.Draw;
			public TimeSpan Duration { get; internal set; }
			public DateTime Timestamp { get; internal set; } = DateTime.Now;
		}

		/// <summary>
		/// Represents a player count peak.
		/// </summary>
		public class Peak
		{
			public int Total { get; internal set; }
			public DateTime Timestamp { get; internal set; } = DateTime.Now;
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

			/// <summary>
			/// Gets the total amount of kills made by SCPs.
			/// </summary>
			public int TotalScpKills => KilledBySCPs;

			/// <summary>
			/// Gets the total amount Scp049-2s created.
			/// </summary>
			public int TotalScp0492Made => ChangedIntoZombies;

			/// <summary>
			/// Gets the total amount Class-Ds who have escaped.
			/// </summary>
			public int TotalEscapedClassD => EscapedClassD;

			/// <summary>
			/// Gets the total amount Scientists who have escaped.
			/// </summary>
			public int TotalEscapedScientists => EscapedScientists;

			/// <summary>
			/// Gets the total amount of SCPs alive.
			/// </summary>
			public int ScpsAlive => SurvivingSCPs;
		}
	}
}
