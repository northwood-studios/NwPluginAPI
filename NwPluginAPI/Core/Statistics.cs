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
		/// Gets the total amount of how many times players connected to server successfully.
		/// </summary>
		public static int TotalConnectedPlayers { get; internal set; }

		/// <summary>
		/// Gets the total amount of how many times connectiong to server got rejected.
		/// </summary>
		public static int TotalRejectedConnections { get; internal set; }

		/// <summary>
		/// Gets the information about timestamp and amount of peak players.
		/// </summary>
		public static Peak PeakPlayers = new Peak();

		/// <summary>
		/// Allows to check how many times server restarted round in this session.
		/// </summary>
		public static int TotalRoundrestarts => RoundRestart.UptimeRounds;

		/// <summary>
		/// Gets the information about fastest round.
		/// </summary>
		public static FastestRound FastestEndedRound;

		/// <summary>
		/// Statistics related to current round.
		/// </summary>
		public static Round CurrentRound = new Round();

		public class FastestRound
		{
			public LeadingTeam LeadingTeam { get; internal set; } = LeadingTeam.Draw;
			public TimeSpan Duration { get; internal set; }
			public DateTime Timestamp { get; internal set; } = DateTime.Now;
		}

		public class Peak
		{
			public int Total { get; internal set; }
			public DateTime Timestamp { get; internal set; } = DateTime.Now;
		}

		public class Round
		{
			/// <summary>
			/// Gets the duration of current round.
			/// </summary>
			public TimeSpan Duration => RoundStart.RoundLength;

			/// <summary>
			/// Gets the round start timestamp.
			/// </summary>
			public DateTime StartTimestamp => DateTime.Now - Statistics.CurrentRound.Duration;

			/// <summary>
			/// Gets the total amount of players deaths.
			/// </summary>
			public int TotalKilledPlayers => RoundSummary.Kills;

			/// <summary>
			/// Gets the total amount of kills madey by SCP.
			/// </summary>
			public int TotalScpKills => RoundSummary.KilledBySCPs;

			/// <summary>
			/// Gets the total amount of created Scp049-2.
			/// </summary>
			public int TotalScp0492Made => RoundSummary.ChangedIntoZombies;

			/// <summary>
			/// Gets the total amount of escaped ClassD.
			/// </summary>
			public int TotalEscapedClassD => RoundSummary.EscapedClassD;

			/// <summary>
			/// Gets the total amount of escaped Scientists.
			/// </summary>
			public int TotalEscapedScientists => RoundSummary.EscapedScientists;

			/// <summary>
			/// Gets the total amount of scps alive.
			/// </summary>
			public int ScpsAlive => RoundSummary.SurvivingSCPs;
		}
	}
}
