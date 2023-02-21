using InventorySystem.Items;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerThrowItem"/>.
	/// </summary>
	public class ThrowingItemEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ThrowingItemEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="item"></param>
		/// <param name="rigidbody"></param>
		public ThrowingItemEventArgs(IPlayer player, ItemBase item, Rigidbody rigidbody)
		{
			Player = (Core.Player)player;
			Item = item;
			Rigidbody = rigidbody;
		}

		/// <summary>
		/// Gets the player throwing item.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get the item being throw.
		/// </summary>
		public ItemBase Item { get; }

		/// <summary>
		/// Gets item rigidbody.
		/// </summary>
		public Rigidbody Rigidbody { get; }
	}
}