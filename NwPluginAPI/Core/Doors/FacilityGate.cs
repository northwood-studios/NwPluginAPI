namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects;
	using PluginAPI.Core;
	using PluginAPI.Core.Zones;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class FacilityGate : FacilityDoor
	{
		public static new List<FacilityGate> List => Facility.Doors.Where(x => x is FacilityGate).Cast<FacilityGate>().ToList();
		public static new int Count => List.Count;

		public new readonly PryableDoor OrginalObject;

		public Transform[] PryPositions => OrginalObject.PryPositions;

		public FacilityGate(FacilityRoom room, PryableDoor door) : base(room, door)
		{
			OrginalObject = door;
		}
	}
}
