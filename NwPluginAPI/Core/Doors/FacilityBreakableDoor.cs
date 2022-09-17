namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects;
	using Interactables.Interobjects.DoorUtils;
	using Core;
	using Zones;
	using System.Collections.Generic;
	using System.Linq;

	public class FacilityBreakableDoor : FacilityDoor
	{
		public new static List<FacilityBreakableDoor> List => Facility.Doors.Where(x => x is FacilityBreakableDoor).Cast<FacilityBreakableDoor>().ToList();
		public new static int Count => List.Count;

		public new readonly BreakableDoor OriginalObject;

		public float Health
		{
			get => OriginalObject.RemainingHealth;
			set => OriginalObject.RemainingHealth = value;
		}

		public float MaxHealth
		{
			get => OriginalObject.MaxHealth;
			set => OriginalObject.MaxHealth = value;
		}
		
		public DoorDamageType IgnoredDamageSources
		{
			get => OriginalObject.IgnoredDamageSources;
			set => OriginalObject.IgnoredDamageSources = value;
		}

		public bool IsDestroyed => OriginalObject.IsDestroyed;

		public void Destroy()
		{
			if (IsDestroyed)
				return;

			OriginalObject.IsDestroyed = true;
			DoorEvents.TriggerAction(OriginalObject, DoorAction.Destroyed, null);
		}

		public FacilityBreakableDoor(FacilityRoom room, BreakableDoor door) : base(room, door)
		{
			OriginalObject = door;
		}
	}
}
