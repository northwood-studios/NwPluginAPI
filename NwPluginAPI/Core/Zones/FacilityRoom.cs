namespace PluginAPI.Core.Zones
{
	using Interactables.Interobjects;
	using Interactables.Interobjects.DoorUtils;
	using MapGeneration;
	using PluginAPI.Core.Doors;
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public class FacilityRoom
	{
		Dictionary<Type, MonoBehaviour> StoredComponents = new Dictionary<Type, MonoBehaviour>();
		internal Dictionary<DoorVariant, FacilityDoor> _doors = new Dictionary<DoorVariant, FacilityDoor>();

		/// <summary>
		/// Gets type of zone.
		/// </summary>
		public readonly FacilityZone Zone;

		/// <summary>
		/// Gets lights controller.
		/// </summary>
		public readonly RoomLight Lights;

		/// <summary>
		/// Gets room identifier.
		/// </summary>
		public readonly RoomIdentifier Identifier;

		/// <summary>
		/// Gets room transform.
		/// </summary>
		public Transform Transform => Identifier.transform;

		/// <summary>
		/// Gets room gameobject.
		/// </summary>
		public GameObject GameObject => Identifier.gameObject;

		/// <summary>
		/// Gets room position.
		/// </summary>
		public Vector3 Position => Transform.position;

		/// <summary>
		/// Gets room rotation.
		/// </summary>
		public Quaternion Rotation => Transform.rotation;

		#region Get Components
		/// <inheritdoc/>
		public T GetComponent<T>(bool globalSearch = false, bool childSearch = false) where T : MonoBehaviour
		{
			if (!StoredComponents.ContainsKey(typeof(T)))
			{
				if (globalSearch)
				{
					var component = UnityEngine.Object.FindObjectOfType<T>();
					if (component == null)
						return null;

					StoredComponents.Add(typeof(T), component);
				}
				else if (childSearch)
				{
					var component = Identifier.gameObject.GetComponentInChildren<T>();
					if (component == null)
						return null;

					StoredComponents.Add(typeof(T), component);
				}
				else
				{
					if (Identifier.gameObject.TryGetComponent(out T component))
						StoredComponents.Add(typeof(T), component);
					else
						return null;
				}
			}

			return (T)StoredComponents[typeof(T)] ?? default;
		}

		/// <inheritdoc/>
		public bool TryGetComponent<T>(out T component, bool globalSearch = false, bool childSearch = false) where T : MonoBehaviour
		{
			if (!StoredComponents.ContainsKey(typeof(T)))
			{
				if (globalSearch)
				{
					component = UnityEngine.Object.FindObjectOfType<T>();
					if (component == null)
						return false;
					StoredComponents.Add(typeof(T), component);
				}
				else if (childSearch)
				{
					component = Identifier.gameObject.GetComponentInChildren<T>();
					if (component == null)
						return false;

					StoredComponents.Add(typeof(T), component);
				}
				else
				{
					if (Identifier.gameObject.TryGetComponent(out component))
						StoredComponents.Add(typeof(T), component);
					else
						return false;
				}
			}

			component = (T)StoredComponents[typeof(T)];
			return true;
		}
		#endregion

		internal void RegisterDoor(DoorVariant door)
		{
			if (!_doors.ContainsKey(door)) return;

			switch (door)
			{
				case BreakableDoor brdoor:
					_doors.Add(door, new FacilityBreakableDoor(this, brdoor));
					break;
				case PryableDoor prydoor:
					_doors.Add(door, new FacilityGate(this, prydoor));
					break;
				default:
					_doors.Add(door, new FacilityDoor(this, door));
					break;
			}
		}

		/// <summary>
		/// Constructor for facility room.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public FacilityRoom(FacilityZone zone, RoomIdentifier room)
		{
			Zone = zone;
			Identifier = room;

			if (room.TryGetComponent(out FlickerableLightController lightController))
				Lights = new RoomLight(lightController);

			Facility.RegisterDoors(this, room.gameObject.GetComponentsInChildren<DoorVariant>());
		}
	}
}
