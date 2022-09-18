namespace PluginAPI.Core
{
	using Interfaces;
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Shared storage between all player classes.
	/// </summary>
	public class PlayerSharedStorage
	{
		private static Dictionary<IPlayer, PlayerSharedStorage> Storage { get; } = new Dictionary<IPlayer, PlayerSharedStorage>();
	
		/// <summary>
		/// Gets player storage.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <returns>The storage.</returns>
		internal static PlayerSharedStorage GetStorage(Player player)
		{
			if (Storage.TryGetValue(player, out PlayerSharedStorage storage))
				return storage;

			storage = new PlayerSharedStorage();
			Storage.Add(player, storage);

			return storage;
		}

		/// <summary>
		/// Destroys players stoarge.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <returns>If storage was destroyed successfully.</returns>
		internal static bool DestroyStorage(IPlayer player) => Storage.Remove(player);

		/// <summary>
		/// Gets stored components.
		/// </summary>
		public Dictionary<Type, MonoBehaviour> StoredComponents { get; } = new Dictionary<Type, MonoBehaviour>();

		/// <summary>
		/// Gets or sets if player can receive damage from players.
		/// </summary>
		public bool CanReceiveDamageFromPlayers { get; set; } = true;

		/// <summary>
		/// Player in this list cant damage this player.
		/// </summary>
		public List<Player> DamageBlacklist { get; } = new List<Player>();

		/// <summary>
		/// Player in this list will be able to damage this player.
		/// </summary>
		public List<Player> DamageWhitelist { get; } = new List<Player>();
	}
}
