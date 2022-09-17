namespace PluginAPI.Core.Items
{
	using InventorySystem.Items;
	using Core;
	using System.Collections.Generic;
	using UnityEngine;

	public class Item
	{
		internal static readonly Dictionary<ushort, Item> CachedItems = new Dictionary<ushort, Item>();

		public readonly ItemBase OriginalObject;

		public ItemType Type => OriginalObject.ItemTypeId;
		public ItemCategory Category => OriginalObject.Category;
		public ItemTierFlags TierFlags => OriginalObject.TierFlags;
		public ItemThrowSettings ThrowSettings => OriginalObject.ThrowSettings;
		public Player CurrentOwner => OriginalObject.Owner == null ? null : Player.Get<Player>(OriginalObject.Owner);
		public ushort Serial => OriginalObject.ItemSerial;
		public float Weight => OriginalObject.Weight;

		public Transform Transform => OriginalObject.transform;
		public GameObject GameObject => OriginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		internal static T GetOrAdd<T>(ItemBase item) where T : Item
		{
			if (CachedItems.TryGetValue(item.ItemSerial, out Item outItem))
				return (T)outItem;
			
			var itm = new Item(item);
			CachedItems.Add(item.ItemSerial, itm);
			return (T)itm;
		}

		internal static bool Remove(ItemBase item)
		{
			if (!CachedItems.TryGetValue(item.ItemSerial, out Item itm)) return false;
			Debug.Log("Remove ITEM " + itm.Type);
			return CachedItems.Remove(item.ItemSerial);
		}

		internal Item(ItemBase item)
		{
			OriginalObject = item;
			Debug.Log("Create new ITEM  " + Type);
		}
	}
}
