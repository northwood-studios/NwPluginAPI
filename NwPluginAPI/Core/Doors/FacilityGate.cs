namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects;
	using Core;
	using Zones;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Interactables.Interobjects.DoorUtils;

	/// <summary>
	/// Represents a gate.
	/// </summary>
	public class FacilityGate : FacilityDoor
	{
		/// <summary>
		/// Gets a list of all the <see cref="FacilityGate"/>'s.
		/// </summary>
		public new static List<FacilityGate> List => Facility.Doors.Where(x => x is FacilityGate).Cast<FacilityGate>().ToList();

		/// <summary>
		/// Gets the total amount of gates.
		/// </summary>
		public new static int Count => List.Count;

		/// <summary>
		/// The base-game object.
		/// </summary>
		public new readonly PryableDoor OriginalObject;

		/// <summary>
		/// Gets the positions the door can be pryed open from.
		/// </summary>
		public Transform[] PryPositions => OriginalObject.PryPositions;

		/// <summary>
		/// Try-get a <see cref="FacilityGate"/> from a <see cref="DoorVariant"/>
		/// </summary>
		/// <param name="baseDoor">The <see cref="DoorVariant"/></param>
		/// <param name="facilityDoor">The <see cref="FacilityGate"/> if its found otherwise will be <see langword="null"/></param>
		/// <returns>A boolean indicating if the <see cref="FacilityGate"/> was found.</returns>
		public static bool TryGet(DoorVariant baseDoor, out FacilityGate facilityDoor)
		{
			if (List == null)
			{
				facilityDoor = null;
				return false;
			}

			facilityDoor = List.FirstOrDefault(door => door.GameObject == baseDoor.gameObject);
			return facilityDoor != null;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FacilityGate"/> class.
		/// </summary>
		/// <param name="room">The room the gate is in.</param>
		/// <param name="gate">The base-game object.</param>
		public FacilityGate(FacilityRoom room, PryableDoor gate) : base(room, gate)
		{
			OriginalObject = gate;
		}
	}
}