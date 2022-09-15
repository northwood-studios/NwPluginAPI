namespace PluginAPI.Core.Doors
{
	using Interactables.Interobjects.DoorUtils;
	using PluginAPI.Core;
	using PluginAPI.Core.Zones;
	using System.Collections.Generic;
	using UnityEngine;

	public class FacilityDoor
	{
		public static List<FacilityDoor> List => Facility.Doors;
		public static int Count => List.Count;

		public readonly DoorVariant OrginalObject;
		public readonly FacilityRoom Room;

		public bool IsOpened
		{
			get => OrginalObject.TargetState;
			set => OrginalObject.TargetState = value;
		}

		public bool IsLocked
		{
			get => (DoorLockReason)OrginalObject.ActiveLocks != DoorLockReason.None;
			set => OrginalObject.ActiveLocks = (ushort)DoorLockReason.AdminCommand;
		}

		public DoorLockReason LockReason
		{
			get => (DoorLockReason)OrginalObject.ActiveLocks;
			set => OrginalObject.ActiveLocks = (ushort)value;
		}

		public KeycardPermissions Permissions
		{
			get => OrginalObject.RequiredPermissions.RequiredPermissions;
			set => OrginalObject.RequiredPermissions.RequiredPermissions = value;
		}

		public bool Bypass2176
		{
			get => OrginalObject.RequiredPermissions.Bypass2176;
			set => OrginalObject.RequiredPermissions.Bypass2176 = value;
		}

		public Transform Transform => OrginalObject.transform;
		public GameObject GameObject => OrginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		public void Lock(DoorLockReason reason, bool enabled) => OrginalObject.ServerChangeLock(reason, enabled);

		public FacilityDoor(FacilityRoom room, DoorVariant door)
		{
			OrginalObject = door;
			Room = room;
			//door.ApiDoor = this;
		}
	}
}
