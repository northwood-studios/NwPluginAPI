using System.Numerics;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items.Pickups;
using JetBrains.Annotations;
using PluginAPI.Core.Doors;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Map
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.ItemSpawned"/>.
	/// </summary>
	public class SpawningItemEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="SpawningItemEventArgs"/>.
		/// </summary>
		/// <param name="item"></param>
		/// <param name="triggerDoor"></param>
		public SpawningItemEventArgs(ItemType item, Vector3 position, string triggerDoor)
		{
			Item = item;
			Position = position;
			TriggerDoor = DoorNametagExtension.NamedDoors.TryGetValue(triggerDoor, out var door) ? FacilityDoor.Get(door.TargetDoor) : null;
		}

		/// <summary>
		/// Get or set <see cref="ItemType"/> spawned.
		/// <remarks>dont set te value in <see cref="ItemType.None"/></remarks>
		/// </summary>
		public ItemType Item { get; set; }

		/// <summary>
		/// Gets item spawn position.
		/// </summary>
		public Vector3 Position { get; }

		/// <summary>
		/// Get or set trigger door.
		/// </summary>
		[CanBeNull]
		public FacilityDoor TriggerDoor { get; set; }
	}
}