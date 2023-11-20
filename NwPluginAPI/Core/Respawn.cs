namespace PluginAPI.Core
{
	using Respawning;
	using static Respawning.RespawnEffectsController;

	/// <summary>
	/// Handles respawning.
	/// </summary>
	public static class Respawn
	{
		/// <summary>
		/// Gets or sets the amount of NTF tickets left.
		/// </summary>
		public static float NtfTickets
		{
			get => RespawnTokensManager.GetTeamDominance(SpawnableTeamType.NineTailedFox);
			set
			{
				RespawnTokensManager.RemoveTokens(SpawnableTeamType.NineTailedFox, NtfTickets);
				AddTickets(SpawnableTeamType.NineTailedFox, value);
			}
		}

		/// <summary>
		/// Gets or sets the amount of chaos tickets left.
		/// </summary>
		public static float ChaosTickets
		{
			get => RespawnTokensManager.GetTeamDominance(SpawnableTeamType.ChaosInsurgency);
			set
			{
				RespawnTokensManager.RemoveTokens(SpawnableTeamType.ChaosInsurgency, ChaosTickets);
				AddTickets(SpawnableTeamType.ChaosInsurgency, value);
			}
		}

		/// <summary>
		/// Gets the next team which will be spawned.
		/// </summary>
		public static SpawnableTeamType NextKnownTeam => RespawnManager.Singleton.NextKnownTeam;

		/// <summary>
		/// Gets the total time, in seconds, until the next respawn wave.
		/// </summary>
		public static int SecondsToNextRepawn => RespawnManager.Singleton.TimeTillRespawn;

		/// <summary>
		/// Gets the current <see cref="RespawnManager.RespawnSequencePhase"/>.
		/// </summary>
		public static RespawnManager.RespawnSequencePhase CurrentRespawnSequence() => RespawnManager.CurrentSequence();

		/// <summary>
		/// Adds tickets to a specific team.
		/// </summary>
		/// <param name="team">The team to add tickets to.</param>
		/// <param name="amount">The amount of tickets to add.</param>
		public static void AddTickets(SpawnableTeamType team, float amount) => RespawnTokensManager.GrantTokens(team, amount);

		/// <summary>
		/// Resets the tokens manager ticket values to the starting value.
		/// </summary>
		public static void ResetTickets() => RespawnTokensManager.ResetTokens();

		/// <summary>
		/// Forces a <see cref="SpawnableTeamType"/> to become the dominant team.
		/// </summary>
		/// <param name="teamType">The <see cref="SpawnableTeamType"/> to force to dominance.</param>
		/// <param name="tokens">The amount of tokens the team will have.</param>
		public static void ForceTeamLead(SpawnableTeamType teamType, float tokens) => RespawnTokensManager.ForceTeamDominance(teamType, tokens);

		/// <summary>
		/// Spawns a specific team.
		/// </summary>
		/// <param name="team">The team to spawn.</param>
		/// <param name="playEffects">Plays spawn effects.</param>
		public static void Spawn(SpawnableTeamType team, bool playEffects = false)
		{
			RespawnManager.Singleton.ForceSpawnTeam(team);
			if (playEffects) ExecuteAllEffects(EffectType.Selection, team);
		}
	}
}