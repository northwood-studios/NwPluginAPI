namespace PluginAPI.Core.Items
{
	using InventorySystem.Items;
	using Core;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Represents an item.
	/// </summary>
	public class Item
	{
		internal static readonly Dictionary<ushort, Item> CachedItems = new Dictionary<ushort, Item>();

		/// <summary>
		/// The base-game object.
		/// </summary>
		public readonly ItemBase OriginalObject;

		/// <summary>
		/// Gets the item's <see cref="ItemType"/>.
		/// </summary>
		public ItemType Type => OriginalObject.ItemTypeId;

		/// <summary>
		/// Gets the item's <see cref="ItemCategory"/>.
		/// </summary>
		public ItemCategory Category => OriginalObject.Category;

		/// <summary>
		/// Gets the item's <see cref="ItemTierFlags"/>.
		/// </summary>
		public ItemTierFlags TierFlags => OriginalObject.TierFlags;

		/// <summary>
		/// Gets the item's <see cref="ItemThrowSettings"/>.
		/// </summary>
		public ItemThrowSettings ThrowSettings => OriginalObject.ThrowSettings;

		/// <summary>
		/// Gets the item's current owner.
		/// </summary>
		public Player CurrentOwner => OriginalObject.Owner == null ? null : Player.Get<Player>(OriginalObject.Owner);

		/// <summary>
		/// Gets the item's serial.
		/// </summary>
		public ushort Serial => OriginalObject.ItemSerial;

		/// <summary>
		/// Gets the item's weight.
		/// </summary>
		public float Weight => OriginalObject.Weight;

		/// <summary>
		/// Gets the item's <see cref="UnityEngine.Transform"/>.
		/// </summary>
		public Transform Transform => OriginalObject.transform;

		/// <summary>
		/// Gets the item's <see cref="UnityEngine.GameObject"/>.
		/// </summary>
		public GameObject GameObject => OriginalObject.gameObject;

		/// <summary>
		/// Gets the item's position.
		/// </summary>
		public Vector3 Position => Transform.position;

		/// <summary>
		/// Gets the items rotation.
		/// </summary>
		public Quaternion Rotation => Transform.rotation;

		internal static T GetOrAdd<T>(ItemBase item) where T : Item
		{
			if (CachedItems.TryGetValue(item.ItemSerial, out Item outItem))
				return (T)outItem;
			
			var itm = new Item(item);
			CachedItems.Add(item.ItemSerial, itm);
			return (T)itm;
		}

		public static bool Remove(ItemBase item)
		{
			if (!CachedItems.TryGetValue(item.ItemSerial, out Item itm)) return false;
			return CachedItems.Remove(item.ItemSerial);
		}

		public Item(ItemBase item)
		{
			OriginalObject = item;
		}
	}
}
