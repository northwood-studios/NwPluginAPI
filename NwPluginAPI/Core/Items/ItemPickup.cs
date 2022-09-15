namespace PluginAPI.Core.Items
{
	using InventorySystem;
	using InventorySystem.Items;
	using InventorySystem.Items.Pickups;
	using Mirror;
	using PluginAPI.Core;
	using System.Collections.Generic;
	using UnityEngine;

	public class ItemPickup
	{
		internal static readonly Dictionary<ushort, ItemPickup> CachedItems = new Dictionary<ushort, ItemPickup>();
		public readonly ItemPickupBase OrginalObject;

		public ItemType Type => OrginalObject.Info.ItemId;
		public Player LastOwner => OrginalObject.PreviousOwner.Hub != null ? Player.Get<Player>(OrginalObject.PreviousOwner.Hub) : null;
		public ushort Serial => OrginalObject.Info.Serial;
		public float Weight
		{
			get => OrginalObject.Info.Weight;
			set => OrginalObject.Info.Weight = value;
		}
		public bool IsLocked
		{
			get => OrginalObject.Info.Locked;
			set => OrginalObject.Info.Locked = value;
		}

		public Rigidbody Rigibody => OrginalObject.RigidBody;
		public Transform Transform => OrginalObject.transform;
		public GameObject GameObject => OrginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		internal static ItemPickup GetOrAdd(ItemPickupBase item)
		{
			if (CachedItems.TryGetValue(item.Info.Serial, out ItemPickup it))
				return it;
			else
			{
				ItemPickup newItem = new ItemPickup(item);
				CachedItems.Add(item.Info.Serial, newItem);
				return newItem;
			}
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
			OrginalObject.InfoReceived(default, OrginalObject.Info);
			NetworkServer.Spawn(GameObject);
		}

		public void Destroy()
		{
			OrginalObject.DestroySelf();
		}

		internal ItemPickup(ItemPickupBase item)
		{
			OrginalObject = item;
			Debug.Log($"Create new PICKUP " + Type);
		}
	}
}
