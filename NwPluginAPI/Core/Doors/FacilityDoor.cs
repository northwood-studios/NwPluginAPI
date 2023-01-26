namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects.DoorUtils;
	using Core;
	using Zones;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Represents a door.
	/// </summary>
	public class FacilityDoor
	{
		/// <summary>
		/// Gets a list of all the <see cref="FacilityDoor"/>s.
		/// </summary>
		public static List<FacilityDoor> List => Facility.Doors;

		/// <summary>
		/// Gets the total amount of doors.
		/// </summary>
		public static int Count => List.Count;

		/// <summary>
		/// The base-game object.
		/// </summary>
		public readonly DoorVariant OriginalObject;

		/// <summary>
		/// The <see cref="FacilityRoom"/> the door is in.
		/// </summary>
		public readonly FacilityRoom Room;

		/// <summary>
		/// Gets or sets whether or not the door is open.
		/// </summary>
		public bool IsOpened
		{
			get => OriginalObject.TargetState;
			set => OriginalObject.TargetState = value;
		}

		/// <summary>
		/// Gets or sets whether or not the door is locked.
		/// </summary>
		public bool IsLocked
		{
			get => (DoorLockReason)OriginalObject.ActiveLocks != DoorLockReason.None;
			set => OriginalObject.ActiveLocks = (ushort)DoorLockReason.AdminCommand;
		}

		/// <summary>
		/// Gets or sets the door's <see cref="DoorLockReason"/>
		/// </summary>
		public DoorLockReason LockReason
		{
			get => (DoorLockReason)OriginalObject.ActiveLocks;
			set => OriginalObject.ActiveLocks = (ushort)value;
		}

		/// <summary>
		/// Gets or sets the required <see cref="KeycardPermissions"/>.
		/// </summary>
		public KeycardPermissions Permissions
		{
			get => OriginalObject.RequiredPermissions.RequiredPermissions;
			set => OriginalObject.RequiredPermissions.RequiredPermissions = value;
		}

		/// <summary>
		/// Gets or sets whether or not the door will bypass 2176.
		/// </summary>
		public bool Bypass2176
		{
			get => OriginalObject.RequiredPermissions.Bypass2176;
			set => OriginalObject.RequiredPermissions.Bypass2176 = value;
		}

		/// <summary>
		/// Gets door name.
		/// </summary>
		public string Name => OriginalObject.name;

		/// <summary>
		/// Gets the door's <see cref="UnityEngine.Transform"/>.
		/// </summary>
		public Transform Transform => OriginalObject.transform;

		/// <summary>
		/// Gets the door's <see cref="UnityEngine.GameObject"/>.
		/// </summary>
		public GameObject GameObject => OriginalObject.gameObject;

		/// <summary>
		/// Gets the door's position.
		/// </summary>
		public Vector3 Position => Transform.position;

		/// <summary>
		/// Gets the door's rotation.
		/// </summary>
		public Quaternion Rotation => Transform.rotation;

		/// <summary>
		/// Locks the door.
		/// </summary>
		/// <param name="reason">The reason.</param>
		/// <param name="enabled">Whether or not the door lock reason is new.</param>
		public void Lock(DoorLockReason reason, bool enabled) => OriginalObject.ServerChangeLock(reason, enabled);

		/// <summary>
		/// Initializes a new instance of the <see cref="FacilityDoor"/> class.
		/// </summary>
		/// <param name="room">The room the door is in.</param>
		/// <param name="door">THe base-game door.</param>
		public FacilityDoor(FacilityRoom room, DoorVariant door)
		{
			OriginalObject = door;
			Room = room;
			//door.ApiDoor = this;
		}
	}
}