namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects.DoorUtils;
	using Core;
	using Zones;
	using System.Collections.Generic;
	using UnityEngine;

	public class FacilityDoor
	{
		public static List<FacilityDoor> List => Facility.Doors;
		public static int Count => List.Count;

		public readonly DoorVariant OriginalObject;
		public readonly FacilityRoom Room;

		public bool IsOpened
		{
			get => OriginalObject.TargetState;
			set => OriginalObject.TargetState = value;
		}

		public bool IsLocked
		{
			get => (DoorLockReason)OriginalObject.ActiveLocks != DoorLockReason.None;
			set => OriginalObject.ActiveLocks = (ushort)DoorLockReason.AdminCommand;
		}

		public DoorLockReason LockReason
		{
			get => (DoorLockReason)OriginalObject.ActiveLocks;
			set => OriginalObject.ActiveLocks = (ushort)value;
		}

		public KeycardPermissions Permissions
		{
			get => OriginalObject.RequiredPermissions.RequiredPermissions;
			set => OriginalObject.RequiredPermissions.RequiredPermissions = value;
		}

		public bool Bypass2176
		{
			get => OriginalObject.RequiredPermissions.Bypass2176;
			set => OriginalObject.RequiredPermissions.Bypass2176 = value;
		}

		public Transform Transform => OriginalObject.transform;
		public GameObject GameObject => OriginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		public void Lock(DoorLockReason reason, bool enabled) => OriginalObject.ServerChangeLock(reason, enabled);

		public FacilityDoor(FacilityRoom room, DoorVariant door)
		{
			OriginalObject = door;
			Room = room;
			//door.ApiDoor = this;
		}
	}
}
