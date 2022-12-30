namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects;
	using Interactables.Interobjects.DoorUtils;
	using Core;
	using Zones;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents a breakable door.
	/// </summary>
	public class FacilityBreakableDoor : FacilityDoor
	{
		/// <summary>
		/// Gets a list of all the <see cref="FacilityBreakableDoor"/>s.
		/// </summary>
		public new static List<FacilityBreakableDoor> List => Facility.Doors.Where(x => x is FacilityBreakableDoor).Cast<FacilityBreakableDoor>().ToList();

		/// <summary>
		/// Gets the total amount of breakable doors.
		/// </summary>
		public new static int Count => List.Count;

		/// <summary>
		/// The base-game object.
		/// </summary>
		public new readonly BreakableDoor OriginalObject;

		/// <summary>
		/// Gets or sets door's health.
		/// </summary>
		public float Health
		{
			get => OriginalObject.RemainingHealth;
			set => OriginalObject.RemainingHealth = value;
		}

		/// <summary>
		/// Gets or sets the doors max health.
		/// </summary>
		public float MaxHealth
		{
			get => OriginalObject.MaxHealth;
			set => OriginalObject.MaxHealth = value;
		}

		/// <summary>
		/// Gets or sets the door's ignored <see cref="DoorDamageType"/>.
		/// </summary>
		public DoorDamageType IgnoredDamageSources
		{
			get => OriginalObject.IgnoredDamageSources;
			set => OriginalObject.IgnoredDamageSources = value;
		}

		/// <summary>
		/// Gets whether or not the door is destroyed.
		/// </summary>
		public bool IsDestroyed => OriginalObject.IsDestroyed;

		/// <summary>
		/// Destroys the door.
		/// </summary>
		public void Destroy()
		{
			if (IsDestroyed)
				return;

			OriginalObject.IsDestroyed = true;
			DoorEvents.TriggerAction(OriginalObject, DoorAction.Destroyed, null);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FacilityBreakableDoor"/> class.
		/// </summary>
		/// <param name="room">The room the door is in.</param>
		/// <param name="door">The base-game door object.</param>
		public FacilityBreakableDoor(FacilityRoom room, BreakableDoor door) : base(room, door)
		{
			OriginalObject = door;
		}
	}
}