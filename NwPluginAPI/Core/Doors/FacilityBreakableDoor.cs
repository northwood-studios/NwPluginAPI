namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects;
	using Interactables.Interobjects.DoorUtils;
	using PluginAPI.Core;
	using PluginAPI.Core.Zones;
	using System.Collections.Generic;
	using System.Linq;

	public class FacilityBreakableDoor : FacilityDoor
	{
		public static new List<FacilityBreakableDoor> List => Facility.Doors.Where(x => x is FacilityBreakableDoor).Cast<FacilityBreakableDoor>().ToList();
		public static new int Count => List.Count;

		public new readonly BreakableDoor OrginalObject;

		public float Health
		{
			get => OrginalObject.RemainingHealth;
			set => OrginalObject.RemainingHealth = value;
		}

		public float MaxHealth
		{
			get => OrginalObject.MaxHealth;
			set => OrginalObject.MaxHealth = value;
		}
		
		public DoorDamageType IgnoredDamageSources
		{
			get => OrginalObject.IgnoredDamageSources;
			set => OrginalObject.IgnoredDamageSources = value;
		}

		public bool IsDestroyed => OrginalObject.IsDestroyed;

		public void Destroy()
		{
			if (!IsDestroyed)
			{
				OrginalObject.IsDestroyed = true;
				DoorEvents.TriggerAction(OrginalObject, DoorAction.Destroyed, null);
			}
		}

		public FacilityBreakableDoor(FacilityRoom room, BreakableDoor door) : base(room, door)
		{
			OrginalObject = door;
		}
	}
}
