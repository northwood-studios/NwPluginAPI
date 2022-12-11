namespace PluginAPI.Core
{
	using Footprinting;
	using PlayerStatsSystem;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Manages damage for a player.
	/// </summary>
	public class DamageManager
	{
		private readonly Player _player;

		/// <summary>
		/// Gets or sets whether or not player can receive damage from other players.
		/// </summary>
		public bool CanReceiveDamageFromPlayers
		{
			get => _player.SharedStorage.CanReceiveDamageFromPlayers;
			set => _player.SharedStorage.CanReceiveDamageFromPlayers = value;
		}

		/// <summary>
		/// Gets a list of players who can't damage this player.
		/// </summary>
		public List<Player> DamageBlacklist => _player.SharedStorage.DamageBlacklist;

		/// <summary>
		/// Gets a list of players who can to damage this player.
		/// </summary>
		public List<Player> DamageWhitelist => _player.SharedStorage.DamageWhitelist;

		/// <summary>
		/// Initializes a new instance of the <see cref="DamageManager"/> class.
		/// </summary>
		/// <param name="plr">The player.</param>
		public DamageManager(Player plr) => _player = plr;
	}
}
