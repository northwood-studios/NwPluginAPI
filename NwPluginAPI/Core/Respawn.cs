using System;
using PlayerRoles;
using Respawning.Waves;

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
		[Obsolete]
		public static float NtfTickets => 0;

		/// <summary>
		/// Gets the amount of NTF tokens left.
		/// </summary>
		public static float NtfTokens
		{
			get
			{
				if(!WaveManager.TryGet(Faction.FoundationStaff, out SpawnableWaveBase wave) || wave is not NtfSpawnWave ntfWave)
					return 0;

				return ntfWave.RespawnTokens;
			}
		}

		/// <summary>
		/// Gets the amount of chaos tickets left.
		/// </summary>
		public static float ChaosTickets => 0;

		/// <summary>
		/// Gets the amount of Chaos tokens left.
		/// </summary>
		public static float ChaosTokens
		{
			get
			{
				if(!WaveManager.TryGet(Faction.FoundationEnemy, out SpawnableWaveBase wave) || wave is not NtfSpawnWave chaosWave)
					return 0;

				return chaosWave.RespawnTokens;
			}
		}

		/// <summary>
		/// Gets the next team which will be spawned.
		/// </summary>
		[Obsolete]
		public static Faction NextKnownTeam => Faction.Unclassified;

		/// <summary>
		/// Adds tickets to a specific team.
		/// </summary>
		/// <param name="team">The team to add tickets to.</param>
		/// <param name="amount">The amount of tickets to add.</param>
		public static void AddTickets(Faction team, float amount)
		{
			switch (team)
			{
				case Faction.FoundationEnemy:
					if (!WaveManager.TryGet(Faction.FoundationEnemy, out SpawnableWaveBase chaosWave) || chaosWave is not NtfSpawnWave chaosSpawnWave)
						return;

					chaosSpawnWave.RespawnTokens += (int)amount;
					break;

				case Faction.FoundationStaff:
					if (!WaveManager.TryGet(Faction.FoundationStaff, out SpawnableWaveBase ntfWave) || ntfWave is not NtfSpawnWave ntfSpawnWave)
						return;

					ntfSpawnWave.RespawnTokens += (int)amount;
					break;
			}
		}

		/// <summary>
		/// Spawns a specific team.
		/// </summary>
		/// <param name="team">The team to spawn.</param>
		/// <param name="playEffects">Plays spawn effects.</param>
		public static void Spawn(Faction team, bool playEffects = false)
		{
			switch (team)
			{
				case Faction.FoundationEnemy:
					if (!WaveManager.TryGet(Faction.FoundationEnemy, out SpawnableWaveBase chaosWave))
						return;

					WaveManager.Spawn(chaosWave);
					if (playEffects)
						WaveManager.InitiateRespawn(chaosWave);
					break;

				case Faction.FoundationStaff:
					if (!WaveManager.TryGet(Faction.FoundationStaff, out SpawnableWaveBase ntfWave))
						return;

					WaveManager.Spawn(ntfWave);
					if (playEffects)
						WaveManager.InitiateRespawn(ntfWave);
					break;
			}
		}
	}
}