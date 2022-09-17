namespace PluginAPI.Core
{
	using Footprinting;
	using PlayerStatsSystem;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// The damage manager for player.
	/// </summary>
	public class DamageManager
	{
		private readonly Player _player;

		/// <summary>
		/// Gets or sets if player can receive damage from players.
		/// </summary>
		public bool CanReceiveDamageFromPlayers
		{
			get => _player.SharedStorage.CanReceiveDamageFromPlayers;
			set => _player.SharedStorage.CanReceiveDamageFromPlayers = value;
		}

		/// <summary>
		/// Player in this list cant damage this player.
		/// </summary>
		public List<Player> DamageBlacklist => _player.SharedStorage.DamageBlacklist;

		/// <summary>
		/// Player in this list will be able to damage this player.
		/// </summary>
		public List<Player> DamageWhitelist => _player.SharedStorage.DamageWhitelist;

		/// <summary>
		/// Constructor for damage manager.
		/// </summary>
		/// <param name="plr">The player.</param>
		public DamageManager(Player plr) => _player = plr;

		/// <summary>
		/// Damages player with custom reason.
		/// </summary>
		/// <param name="amount">The amount of damage.</param>
		/// <param name="reason">The reason of damage.</param>
		/// <param name="cassieAnnouncement">The cassie announcement send after death.</param>
		/// <returns>If damage is successful.</returns>
		public bool Damage(float amount, string reason, string cassieAnnouncement = "") => Damage(new CustomReasonDamageHandler(reason, amount, cassieAnnouncement));

		/// <summary>
		/// Damages player with explosion force.
		/// </summary>
		/// <param name="amount">The amount of damage.</param>
		/// <param name="attacker">The player which attacked</param>
		/// <param name="force">The force of explosion.</param>
		/// <param name="armorPenetration">The amount of armor penetration.</param>
		/// <returns>If damage is successful.</returns>
		public bool Damage(float amount, Player attacker, Vector3 force = default, int armorPenetration = 0) => Damage(new ExplosionDamageHandler(new Footprint(attacker.ReferenceHub), force, amount, armorPenetration));

		/// <summary>
		/// Damages player.
		/// </summary>
		/// <param name="damageHandlerBase">The damage handler base.</param>
		/// <returns>If damage is successful.</returns>
		public bool Damage(DamageHandlerBase damageHandlerBase) => _player.ReferenceHub.playerStats.DealDamage(damageHandlerBase);
	}
}
