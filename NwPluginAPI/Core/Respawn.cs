namespace PluginAPI.Core
{
	using Respawning;
	using static Respawning.RespawnEffectsController;

	/// <summary>
	/// Handles respawning
	/// </summary>
	public static class Respawn
	{
		/// <summary>
		/// Gets the amount of NTF tickets left.
		/// </summary>
		public static float NtfTickets => RespawnTokensManager.GetTeamDominance(SpawnableTeamType.NineTailedFox);

		/// <summary>
		/// Gets the amount of chaos tickets left.
		/// </summary>
		public static float ChaosTickets => RespawnTokensManager.GetTeamDominance(SpawnableTeamType.ChaosInsurgency);

		/// <summary>
		/// Gets the next team which will be spawned.
		/// </summary>
		public static SpawnableTeamType NextKnownTeam => RespawnManager.Singleton.NextKnownTeam;

		/// <summary>
		/// Adds tickets to a specific team.
		/// </summary>
		/// <param name="team">The team to add tickets to.</param>
		/// <param name="amount">The amount of tickets to add.</param>
		public static void AddTickets(SpawnableTeamType team, float amount) => RespawnTokensManager.GrantTokens(team, amount);

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
