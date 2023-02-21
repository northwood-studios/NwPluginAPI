using System;
using JetBrains.Annotations;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Items;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerChangeItem"/>.
	/// </summary>
	public class ChangingItemEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChangingItemEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="oldItemSerial"></param>
		/// <param name="newItemSerial"></param>
		public ChangingItemEventArgs(IPlayer player, ushort oldItemSerial, ushort newItemSerial)
		{
			Player = (Core.Player)player;
			if (Player.ReferenceHub.inventory.UserInventory.Items.TryGetValue(oldItemSerial, out var oldItem))
				OldItem = Item.GetOrAdd<Item>(oldItem);
			if (Player.ReferenceHub.inventory.UserInventory.Items.TryGetValue(newItemSerial, out var newItem))
				NewItem = Item.GetOrAdd<Item>(newItem);
		}

		/// <summary>
		/// Gets the player who's changing item.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player old item.
		/// </summary>
		public Item OldItem { get; }

		/// <summary>
		/// Get or set new item.
		/// </summary>
		public Item NewItem
		{
			get => NewItem;
			set
			{
				if (!Player.ReferenceHub.inventory.UserInventory.Items.TryGetValue(value.Serial, out _))
					throw new InvalidOperationException($"{nameof(NewItem)} cannot be assigned an item that the player does not have in their inventory.");

				NewItem = value;
			}
		}
	}
}