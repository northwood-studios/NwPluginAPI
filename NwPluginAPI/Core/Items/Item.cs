namespace PluginAPI.Core.Items
{
	using InventorySystem.Items;
	using PluginAPI.Core;
	using System.Collections.Generic;
	using UnityEngine;

	public class Item
	{
		internal static readonly Dictionary<ushort, Item> CachedItems = new Dictionary<ushort, Item>();

		public readonly ItemBase OrginalObject;

		public ItemType Type => OrginalObject.ItemTypeId;
		public ItemCategory Category => OrginalObject.Category;
		public ItemTierFlags TierFlags => OrginalObject.TierFlags;
		public ItemThrowSettings ThrowSettings => OrginalObject.ThrowSettings;
		public Player CurrentOwner => OrginalObject.Owner == null ? null : Player.Get<Player>(OrginalObject.Owner);
		public ushort Serial => OrginalObject.ItemSerial;
		public float Weight => OrginalObject.Weight;

		public Transform Transform => OrginalObject.transform;
		public GameObject GameObject => OrginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		internal static T GetOrAdd<T>(ItemBase item) where T : Item
		{
			if (CachedItems.TryGetValue(item.ItemSerial, out Item outItem))
				return (T)outItem;
			else
			{
				Item itm = new Item(item);
				CachedItems.Add(item.ItemSerial, itm);
				return (T)itm;
			}
		}

		internal static bool Remove(ItemBase item)
		{
			if (!CachedItems.TryGetValue(item.ItemSerial, out Item itm)) return false;
			Debug.Log($"Remove ITEM " + itm.Type);
			return CachedItems.Remove(item.ItemSerial);
		}

		internal Item(ItemBase item)
		{
			OrginalObject = item;
			Debug.Log($"Create new ITEM  " + Type);
		}
	}
}
