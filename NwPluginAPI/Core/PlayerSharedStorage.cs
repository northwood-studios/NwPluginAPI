namespace PluginAPI.Core
{
	using PluginAPI.Core.Interfaces;
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Shared storage between all player classes.
	/// </summary>
	public class PlayerSharedStorage
	{
		static Dictionary<IPlayer, PlayerSharedStorage> Storage { get; } = new Dictionary<IPlayer, PlayerSharedStorage>();
	
		/// <summary>
		/// Gets player storage.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <returns>The storage.</returns>
		internal static PlayerSharedStorage GetStorage(Player player)
		{
			if (!Storage.TryGetValue(player, out PlayerSharedStorage storage))
			{
				storage = new PlayerSharedStorage(player);
				Storage.Add(player, storage);
			}

			return storage;
		}

		/// <summary>
		/// Destroys players stoarge.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <returns>If storage was destroyed successfully.</returns>
		internal static bool DestroyStorage(IPlayer player) => Storage.Remove(player);

		private Player _player;

		internal PlayerSharedStorage(Player player)
		{
			_player = player;
		}

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
