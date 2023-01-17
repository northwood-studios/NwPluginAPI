using System.Reflection;

namespace PluginAPI.Core
{
	using GameCore;
	using RoundRestarting;
	using System;
	using static ServerStatic;

	public static class Round
	{
		/// <summary>
		/// Gets a value indicating whether the round is started or not.
		/// </summary>
		public static bool IsRoundStarted => RoundSummary.RoundInProgress();

		/// <summary>
		/// Gets a value indicating whether the round is ended or not.
		/// </summary>
		public static bool IsRoundEnded => !IsRoundStarted && Round.Duration.Seconds > 1;

		/// <summary>
		/// Gets or sets a value indicating whether the round is locked or not.
		/// </summary>
		public static bool IsLocked
		{
			get => RoundSummary.RoundLock;
			set => RoundSummary.RoundLock = value;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the lobby is locked or not.
		/// </summary>
		public static bool IsLobbyLocked
		{
			get => RoundStart.LobbyLock;
			set => RoundStart.LobbyLock = value;
		}

		/// <summary>
		/// Gets the duration of the current round.
		/// </summary>
		public static TimeSpan Duration => RoundStart.RoundLength;

		/// <summary>
		/// Restarts round.
		/// </summary>
		/// <param name="fastRestart">Whether or not it fast restart is enabled.</param>
		/// <param name="overrideRestartAction">Overrides stop next round action.</param>
		/// <param name="restartAction">The restart action.</param>
		public static void Restart(bool fastRestart = true, bool overrideRestartAction = false, NextRoundAction restartAction = NextRoundAction.Restart)
		{
			if (overrideRestartAction) StopNextRound = restartAction;

			bool oldValue = CustomNetworkManager.EnableFastRestart;

			CustomNetworkManager.EnableFastRestart = fastRestart;
			RoundRestart.InitiateRoundRestart();
			CustomNetworkManager.EnableFastRestart = oldValue;
		}

		/// <summary>
		/// Restarts the round silently.
		/// </summary>
		public static void RestartSilently() => Restart(true, true, NextRoundAction.DoNothing);

		/// <summary>
		/// Start the round.
		/// </summary>
		public static void Start() => CharacterClassManager.ForceRoundStart();

		/// <summary>
		/// Ends current round.
		/// </summary>
		/// <returns>A <see cref="bool"/> describing whether or not the round was successfully ended.</returns>
		public static bool End()
		{
			if (RoundSummary.singleton.KeepRoundOnOne && Player.Count < 2) return false;

			if (!IsRoundStarted || IsLocked)
				return false;

			RoundSummary.singleton.ForceEnd();
			return true;

		}
	}
}