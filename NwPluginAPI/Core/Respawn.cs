namespace PluginAPI.Core
{
	using Respawning;
	using static Respawning.RespawnEffectsController;

	public static class Respawn
	{
		/// <summary>
		/// Gets the amount of NTF tickets.
		/// </summary>
		public static float NtfTickets => RespawnTokensManager.GetTeamDominance(SpawnableTeamType.NineTailedFox);

		/// <summary>
		/// Gets the amount of chaos tickets.
		/// </summary>
		public static float ChaosTickets => RespawnTokensManager.GetTeamDominance(SpawnableTeamType.ChaosInsurgency);

		/// <summary>
		/// Gets the next team which will be spawned
		/// </summary>
		public static SpawnableTeamType NextKnownTeam => RespawnManager.Singleton.NextKnownTeam;

		/// <summary>
		/// Add tickets to specific team.
		/// </summary>
		/// <param name="team">The team type.</param>
		/// <param name="amount">The amount of tickets.</param>
		public static void AddTickets(SpawnableTeamType team, float amount) => RespawnTokensManager.GrantTokens(team, amount);

		/// <summary>
		/// Spawns specific team.
		/// </summary>
		/// <param name="team">The team type.</param>
		/// <param name="playEffects">Play effects like chaos van arrive or helicopter land.</param>
		public static void Spawn(SpawnableTeamType team, bool playEffects = false)
		{
			RespawnManager.Singleton.ForceSpawnTeam(team);
			if (playEffects) ExecuteAllEffects(EffectType.Selection, team);
		}
	}
}
