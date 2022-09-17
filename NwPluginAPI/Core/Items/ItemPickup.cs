namespace PluginAPI.Core.Items
{
	using InventorySystem;
	using InventorySystem.Items;
	using InventorySystem.Items.Pickups;
	using Mirror;
	using Core;
	using System.Collections.Generic;
	using UnityEngine;

	public class ItemPickup
	{
		private static readonly Dictionary<ushort, ItemPickup> CachedItems = new Dictionary<ushort, ItemPickup>();
		
		public readonly ItemPickupBase OriginalObject;

		public ItemType Type => OriginalObject.Info.ItemId;
		public Player LastOwner => OriginalObject.PreviousOwner.Hub != null ? Player.Get<Player>(OriginalObject.PreviousOwner.Hub) : null;
		public ushort Serial => OriginalObject.Info.Serial;
		public float Weight
		{
			get => OriginalObject.Info.Weight;
			set => OriginalObject.Info.Weight = value;
		}
		public bool IsLocked
		{
			get => OriginalObject.Info.Locked;
			set => OriginalObject.Info.Locked = value;
		}

		public Rigidbody Rigidbody => OriginalObject.RigidBody;
		public Transform Transform => OriginalObject.transform;
		public GameObject GameObject => OriginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		private static ItemPickup GetOrAdd(ItemPickupBase item)
		{
			if (CachedItems.TryGetValue(item.Info.Serial, out ItemPickup it))
				return it;
			
			var newItem = new ItemPickup(item);
			CachedItems.Add(item.Info.Serial, newItem);
			return newItem;
		}

		internal static bool Remove(ItemPickupBase item)
		{
			if (!CachedItems.TryGetValue(item.Info.Serial, out ItemPickup it)) return false;

			Debug.Log($"Remove ITEM PICKUP " + it.Type);
			return CachedItems.Remove(item.Info.Serial);
		}

		public static ItemPickup Create(ItemType item, Vector3 position, Quaternion rotation)
		{
			if (item == ItemType.None || !InventoryItemLoader.AvailableItems.TryGetValue(item, out ItemBase ib))
				return null;

			ItemPickupBase newPickup = Object.Instantiate(ib.PickupDropModel, position, rotation);
			newPickup.Info.ItemId = item;
			newPickup.Info.ServerSetPositionAndRotation(position, rotation);
			newPickup.Info.Serial = ItemSerialGenerator.GenerateNext();
			newPickup.Info.Weight = ib.Weight;

			return GetOrAdd(newPickup);
		}

		public void Spawn()
		{
			OriginalObject.InfoReceived(default, OriginalObject.Info);
			NetworkServer.Spawn(GameObject);
		}

		public void Destroy()
		{
			OriginalObject.DestroySelf();
		}

		internal ItemPickup(ItemPickupBase item)
		{
			OriginalObject = item;
			Debug.Log($"Create new PICKUP " + Type);
		}
	}
}
