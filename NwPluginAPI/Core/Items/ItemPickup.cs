namespace PluginAPI.Core.Items
{
	using InventorySystem;
	using InventorySystem.Items;
	using InventorySystem.Items.Pickups;
	using Mirror;
	using Core;
	using System.Collections.Generic;
	using UnityEngine;
	using PluginAPI.Core.Zones;
	using MapGeneration;

	public class ItemPickup
	{
		private static readonly Dictionary<ushort, ItemPickup> CachedItems = new Dictionary<ushort, ItemPickup>();
		private PickupStandardPhysics? _pickupStandardPhysics;

		// This values are from ItemPickupBase
		private const float MinimalPickupTime = 0.245f;
		private const float WeightToTime = 0.175f;

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
		public Player? LastOwner => OriginalObject.PreviousOwner.Hub != null ? Player.Get<Player>(OriginalObject.PreviousOwner.Hub) : null;

		/// <summary>
		/// Gets the pickup's serial.
		/// </summary>
		public ushort Serial => OriginalObject.Info.Serial;

		/// <summary>
		/// Gets or sets the pickup's weight.
		/// </summary>
		public float Weight
		{
			get => OriginalObject.Info.WeightKg;
			set => OriginalObject.Info.WeightKg = value;
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
		/// Gets or sets whether the item pickup is currently in use.
		/// </summary>
		/// <value>True if the item pickup is in use; otherwise, false.</value>
		public bool InUse
		{
			get => OriginalObject.Info.InUse;
			set => OriginalObject.Info.InUse = value;
		}

		/// <summary>
		/// Gets the pickup's <see cref="PickupStandardPhysics"/>.
		/// </summary>
		public PickupStandardPhysics? PickupStandardPhysics
		{
			get
			{
				_pickupStandardPhysics ??= (PickupStandardPhysics)OriginalObject.PhysicsModule;
				return _pickupStandardPhysics;
			}
		}

		/// <summary>
		/// Gets the pickup's <see cref="UnityEngine.Rigidbody"/>.
		/// </summary>
		public Rigidbody? Rigidbody => PickupStandardPhysics?.Rb;

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
		public Vector3 Position
		{
			get => OriginalObject.Position;
			set => OriginalObject.Position = value;
		}

		/// <summary>
		/// Gets or sets the rotation of the pickup.
		/// </summary>
		/// <value>The rotation of the item pickup as a <see cref="Quaternion"/>.</value>
		public Quaternion Rotation
		{
			get => OriginalObject.Rotation;
			set => OriginalObject.Rotation = value;
		}

		/// <summary>
		/// Gets or sets the scale of the pickup.
		/// </summary>
		/// <value>The scale of the pickup as a <see cref="Vector3"/>.</value>
		public Vector3 Scale
		{
			get => OriginalObject.transform.localScale;
			set
			{
				// If the provided scale matches the current scale, no action is taken.
				if (value == OriginalObject.transform.localScale)
					return;

				// If the object has not been spawned on the network, set the scale directly.
				if (!NetworkServer.spawned.ContainsKey(OriginalObject.netId))
				{
					OriginalObject.transform.localScale = value;
				}
				else
				{
					// Unspawn the item pickup, set the scale, and then spawn it again.
					UnSpawn();
					OriginalObject.transform.localScale = value;
					Spawn();
				}
			}
		}

		/// <summary>
		/// Gets or sets the time it takes to pick up this pickup based on its weight.
		/// </summary>
		/// <value>The pickup time in seconds.</value>
		public float PickupTime
		{
			get => MinimalPickupTime + (WeightToTime * Weight);
			set => Weight = MinimalPickupTime - (WeightToTime / value);
		}

		/// <summary>
		/// Gets the time it takes to pick up this item for a specific <see cref="Player"/>.
		/// </summary>
		/// <param name="player">The <see cref="Player"/> attempting to pick up the item.</param>
		/// <returns>The pickup time in seconds for the specified player.</returns>
		public float PickupTimeForPlayer(Player player)
		{
			return OriginalObject.SearchTimeForPlayer(player.ReferenceHub);
		}

		/// <summary>
		/// Gets the room in which this item pickup is located.
		/// </summary>
		/// <value>The <see cref="RoomIdentifier"/> representing the room or null if not found.</value>
		public RoomIdentifier? Room => RoomIdUtils.RoomAtPositionRaycasts(Position);

		/// <summary>
		/// Gets an existing <see cref="ItemPickup"/> associated with the given <see cref="ItemPickupBase"/> or adds a new one if not found.
		/// </summary>
		/// <param name="item">The <see cref="ItemPickupBase"/> to look up or add.</param>
		/// <returns>The existing or newly created <see cref="ItemPickup"/> associated with the input item.</returns>
		private static ItemPickup GetOrAdd(ItemPickupBase item)
		{
			if (CachedItems.TryGetValue(item.Info.Serial, out ItemPickup it))
				return it;

			var newItem = new ItemPickup(item);
			CachedItems.Add(item.Info.Serial, newItem);
			return newItem;
		}

		/// <summary>
		/// Removes an existing <see cref="ItemPickup"/> associated with the given <see cref="ItemPickupBase"/>.
		/// </summary>
		/// <param name="item">The <see cref="ItemPickupBase"/> to remove from the cache.</param>
		/// <returns>True if an associated <see cref="ItemPickup"/> was found and removed; otherwise, false.</returns>
		public static bool Remove(ItemPickupBase item)
		{
			if (!CachedItems.TryGetValue(item.Info.Serial, out _))
				return false;

			return CachedItems.Remove(item.Info.Serial);
		}

		/// <summary>
		/// Creates a new <see cref="ItemPickup"/>.
		/// </summary>
		/// <param name="item">The <see cref="ItemType"/>.</param>
		/// <param name="position">The position.</param>
		/// <param name="rotation">The rotation.</param>
		/// <returns>The created <see cref="ItemPickup"/>.</returns>
		public static ItemPickup? Create(ItemType item, Vector3 position, Quaternion rotation = default)
		{
			if (item == ItemType.None || !InventoryItemLoader.AvailableItems.TryGetValue(item, out ItemBase ib))
				return null;

			PickupSyncInfo syncInfo = new()
			{
				ItemId = item,
				Serial = ItemSerialGenerator.GenerateNext(),
				WeightKg = ib.Weight
			};

			ItemPickupBase newPickup = InventoryExtensions.ServerCreatePickup(ib, syncInfo, position, rotation, false);
			return GetOrAdd(newPickup);
		}

		/// <summary>
		/// Creates a new <see cref="ItemPickup"/> and spawns it.
		/// </summary>
		/// <param name="type">The <see cref="ItemType"/> of the item.</param>
		/// <param name="position">The position where the pickup should be created.</param>
		/// <param name="rotation">The rotation of the pickup (optional).</param>
		/// <returns>The created and spawned <see cref="ItemPickup"/> if successful, otherwise null.</returns>
		public static ItemPickup? CreateAndSpawn(ItemType type, Vector3 position, Quaternion rotation = default)
		{
			var pickup = Create(type, position, rotation);
			pickup?.Spawn();
			return pickup;
		}

		/// <summary>
		/// Creates a new <see cref="ItemPickup"/>.
		/// </summary>
		/// <param name="type">The <see cref="ItemType"/> of the item.</param>
		/// <param name="position">The position where the pickup should be created.</param>
		/// <param name="pickupInfo">Additional pickup information.</param>
		/// <param name="rotation">The rotation of the pickup (optional).</param>
		/// <returns>The created <see cref="ItemPickup"/> if successful, otherwise null.</returns>
		public static ItemPickup? Create(ItemType type, Vector3 position, PickupSyncInfo pickupInfo)
		{
			if (type == ItemType.None || !InventoryItemLoader.AvailableItems.TryGetValue(type, out ItemBase ib))
				return null;

			if(pickupInfo.Serial == 0 || pickupInfo.ItemId == ItemType.None)
				return null;

			ItemPickupBase newPickup = InventoryExtensions.ServerCreatePickup(ib, pickupInfo, position, false);

			return GetOrAdd(newPickup);
		}

		/// <summary>
		/// Creates a clone of the current <see cref="ItemPickup"/> with a new serial.
		/// </summary>
		/// <returns>The cloned <see cref="ItemPickup"/>.</returns>
		public ItemPickup? Clone()
		{
			PickupSyncInfo newInfo = new()
			{
				ItemId = Type,
				Serial = ItemSerialGenerator.GenerateNext(),
				WeightKg = Weight
			};

			return Create(Type, Position, newInfo);
		}

		/// <summary>
		/// Spawns the pickup.
		/// </summary>
		public void Spawn()
		{
			NetworkServer.Spawn(GameObject);
		}

		/// <summary>
		/// Unspawn the pickup.
		/// </summary>
		public void UnSpawn()
		{
			NetworkServer.UnSpawn(GameObject);
		}

		/// <summary>
		/// Destroys the pickup.
		/// </summary>
		public void Destroy()
		{
			OriginalObject.DestroySelf();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemPickup"/> class based on an existing <see cref="ItemPickupBase"/>.
		/// </summary>
		/// <param name="item">The original <see cref="ItemPickupBase"/> to associate with this <see cref="ItemPickup"/>.</param>
		public ItemPickup(ItemPickupBase item)
		{
			OriginalObject = item;
		}

		/// <summary>
		/// Returns a string representation of the item pickup, including important related data.
		/// </summary>
		/// <returns>A string containing information about the item pickup.</returns>
		public override string ToString() => $"{Type} - {Serial} | {Weight} - *{Scale}* | {Position} | {IsLocked} - {InUse}";
	}
}