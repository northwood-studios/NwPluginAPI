namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects;
	using Core;
	using Zones;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class FacilityGate : FacilityDoor
	{
		public new static List<FacilityGate> List => Facility.Doors.Where(x => x is FacilityGate).Cast<FacilityGate>().ToList();
		public new static int Count => List.Count;

		public new readonly PryableDoor OriginalObject;

		public Transform[] PryPositions => OriginalObject.PryPositions;

		public FacilityGate(FacilityRoom room, PryableDoor door) : base(room, door)
		{
			OriginalObject = door;
		}
	}
}
