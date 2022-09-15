namespace PluginAPI.Core
{
	using Respawning;
	using static Respawning.RespawnEffectsController;

	public static class Respawn
	{
		/// <summary>
		/// Gets the amount of NTF tickets.
		/// </summary>
		public static int NtfTickets => RespawnTickets.Singleton.GetAvailableTickets(SpawnableTeamType.NineTailedFox);

		/// <summary>
		/// Gets the amount of chaos tickets.
		/// </summary>
		public static int ChaosTickets => RespawnTickets.Singleton.GetAvailableTickets(SpawnableTeamType.ChaosInsurgency);

		/// <summary>
		/// Gets the next team which will be spawned
		/// </summary>
		public static SpawnableTeamType NextKnownTeam => RespawnManager.Singleton.NextKnownTeam;

		/// <summary>
		/// Add tickets to specific team.
		/// </summary>
		/// <param name="team">The team type.</param>
		/// <param name="amount">The amount of tickets.</param>
		/// <param name="overrideLocks"></param>
		/// <returns></returns>
		public static bool AddTickets(SpawnableTeamType team, int amount, bool overrideLocks = false) => RespawnTickets.Singleton.GrantTickets(team, amount, overrideLocks);

		/// <summary>
		/// Spawns specific team.
		/// </summary>
		/// <param name="team">The team type.</param>
		/// <param name="playEffects">Play effects like chaos van arrive or helicopter land.</param>
		public static void Spawn(SpawnableTeamType team, bool playEffects = false)
		{
			RespawnManager.Singleton.ForceSpawnTeam(team);
			if (playEffects) RespawnEffectsController.ExecuteAllEffects(EffectType.Selection, team);
		}
	}
}
