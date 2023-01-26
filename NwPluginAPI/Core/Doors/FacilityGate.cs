namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects;
	using Core;
	using Zones;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

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
		/// Gets gate name.
		/// </summary>
		public string Name => OriginalObject.name;

		/// <summary>
		/// The base-game object.
		/// </summary>
		public new readonly PryableDoor OriginalObject;

		/// <summary>
		/// Gets the positions the door can be pryed open from.
		/// </summary>
		public Transform[] PryPositions => OriginalObject.PryPositions;

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