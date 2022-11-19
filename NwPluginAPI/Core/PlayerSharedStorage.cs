namespace PluginAPI.Core
{
	using Interfaces;
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Represents shared storage between all player classes.
	/// </summary>
	public class PlayerSharedStorage
	{
		private static Dictionary<IPlayer, PlayerSharedStorage> Storage { get; } = new Dictionary<IPlayer, PlayerSharedStorage>();
	
		/// <summary>
		/// Gets a players storage.
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
		/// Destroys a players storage.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <returns>Whether or not the storage was destroyed successfully.</returns>
		internal static bool DestroyStorage(IPlayer player) => Storage.Remove(player);

		/// <summary>
		/// Gets stored components.
		/// </summary>
		public Dictionary<Type, MonoBehaviour> StoredComponents { get; } = new Dictionary<Type, MonoBehaviour>();

		/// <summary>
		/// Gets or sets whether or not player can receive damage from players.
		/// </summary>
		public bool CanReceiveDamageFromPlayers { get; set; } = true;

		/// <summary>
		/// Gets a list of players which can't damage this player.
		/// </summary>
		public List<Player> DamageBlacklist { get; } = new List<Player>();

		/// <summary>
		/// Gets a list of players which can damage this player.
		/// </summary>
		public List<Player> DamageWhitelist { get; } = new List<Player>();
	}
}
