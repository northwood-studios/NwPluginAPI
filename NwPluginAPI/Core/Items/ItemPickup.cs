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

		/// <summary>
		/// The base-game object.
		/// </summary>
		public readonly ItemPickupBase OriginalObject;

		/// <summary>
		/// Gets the pickup's <see cref="ItemType"/>.
		/// </summary>
		public ItemType Type => OriginalObject.Info.ItemId;

		/// <summary>
		/// Gets the pickup's previous owner.
		/// </summary>
		public Player LastOwner => OriginalObject.PreviousOwner.Hub != null ? Player.Get<Player>(OriginalObject.PreviousOwner.Hub) : null;

		/// <summary>
		/// Gets the pickup's serial.
		/// </summary>
		public ushort Serial => OriginalObject.Info.Serial;

		/// <summary>
		/// Gets or sets the pickup's weight.
		/// </summary>
		public float Weight
		{
			get => OriginalObject.Info.Weight;
			set => OriginalObject.Info.Weight = value;
		}

		/// <summary>
		/// Gets or sets whether or not the pickup is locked.
		/// </summary>
		public bool IsLocked
		{
			get => OriginalObject.Info.Locked;
			set => OriginalObject.Info.Locked = value;
		}

		/// <summary>
		/// Gets the pickup's <see cref="UnityEngine.Rigidbody"/>.
		/// </summary>
		public Rigidbody Rigidbody => OriginalObject.RigidBody;

		/// <summary>
		/// Gets the pickup's <see cref="UnityEngine.Rigidbody"/>.
		/// </summary>
		public Transform Transform => OriginalObject.transform;

		/// <summary>
		/// Gets the pickup's <see cref="UnityEngine.GameObject"/>.
		/// </summary>
		public GameObject GameObject => OriginalObject.gameObject;

		/// <summary>
		/// Gets the pickup's position.
		/// </summary>
		public Vector3 Position => Transform.position;

		/// <summary>
		/// Gets the pickup's rotation.
		/// </summary>
		public Quaternion Rotation => Transform.rotation;

		private static ItemPickup GetOrAdd(ItemPickupBase item)
		{
			if (CachedItems.TryGetValue(item.Info.Serial, out ItemPickup it))
				return it;
			
			var newItem = new ItemPickup(item);
			CachedItems.Add(item.Info.Serial, newItem);
			return newItem;
		}

		public static bool Remove(ItemPickupBase item)
		{
			if (!CachedItems.TryGetValue(item.Info.Serial, out ItemPickup it)) return false;

			return CachedItems.Remove(item.Info.Serial);
		}

		/// <summary>
		/// Creates a new <see cref="ItemPickup"/>.
		/// </summary>
		/// <param name="item">The <see cref="ItemType"/>.</param>
		/// <param name="position">The position.</param>
		/// <param name="rotation">The rotation.</param>
		/// <returns>The created <see cref="ItemPickup"/>.</returns>
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

		/// <summary>
		/// Spawns the pickup.
		/// </summary>
		public void Spawn()
		{
			OriginalObject.InfoReceived(default, OriginalObject.Info);
			NetworkServer.Spawn(GameObject);
		}

		/// <summary>
		/// Destroys the pickup.
		/// </summary>
		public void Destroy()
		{
			OriginalObject.DestroySelf();
		}

		public ItemPickup(ItemPickupBase item)
		{
			OriginalObject = item;
		}
	}
}
