using AdminToys;
using PlayerStatsSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Items;
using PluginAPI.Enums;
using UnityEngine;
using Utils.Networking;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDamagedShootingTarget"/>.
	/// </summary>
	public class DamagingShootingTargetEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DamagingShootingTargetEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="target"></param>
		/// <param name="exactHit"></param>
		/// <param name="damageAmount"></param>
		public DamagingShootingTargetEventArgs(IPlayer player, ShootingTarget target, Vector3 exactHit, float damageAmount)
		{
			Player = (Core.Player)player;
			ShootingTarget = target;
			HitLocation = exactHit;
			Amount = damageAmount;
			Item = Item.GetOrAdd<Item>(Player.CurrentItem);
		}

		/// <summary>
		/// Gets the player damaging shooting target.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the shooting target damaged.
		/// </summary>
		public ShootingTarget ShootingTarget { get; }

		/// <summary>
		/// Gets the exact world location the bullet impacted the target.
		/// </summary>
		public Vector3 HitLocation { get; }

		/// <summary>
		/// Get or set damage amount.
		/// </summary>
		public float Amount { get; set; }

		/// <summary>
		/// Gets the item used to deal damage.
		/// </summary>
		public Item Item { get; }
	}
}