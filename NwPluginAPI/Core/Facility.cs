namespace PluginAPI.Core
{
	using Interactables.Interobjects;
	using Interactables.Interobjects.DoorUtils;
	using MapGeneration;
	using PluginAPI.Core.Doors;
	using PluginAPI.Core.Zones;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using FacilityZone = Zones.FacilityZone;

	/// <summary>
	/// Facility.
	/// </summary>
	public class Facility
	{
		internal static Dictionary<int, FacilityZone> _zones = new Dictionary<int, FacilityZone>();
		internal static Dictionary<Type, MapGeneration.FacilityZone> _typeToZone = new Dictionary<Type, MapGeneration.FacilityZone>()
		{
			{ typeof(EntranceZone), MapGeneration.FacilityZone.Entrance },
			{ typeof(HeavyZone), MapGeneration.FacilityZone.HeavyContainment },
			{ typeof(LightZone), MapGeneration.FacilityZone.LightContainment },
			{ typeof(SurfaceZone), MapGeneration.FacilityZone.Surface },
			{ typeof(UnknownZone), MapGeneration.FacilityZone.Other },
		};

		internal static FacilityRoom GetRoom(RoomIdentifier roomIdentity)
		{
			if (roomIdentity == null) return null;

			TryGetRoom(roomIdentity, out FacilityRoom room);
			return room;
		}

		internal static bool TryGetRoom(RoomIdentifier roomIdentity, out FacilityRoom room)
		{
			if (roomIdentity == null)
			{
				room = null;
				return false;
			}

			if (!TryGetZone(roomIdentity.Zone, out FacilityZone zone))
			{
				room = null;
				return false;
			}

			return zone.TryGetRoom(roomIdentity, out room);
		}

		internal static bool TryGetZone<T>(out FacilityZone facilityZone) where T : FacilityZone
		{
			if (!_typeToZone.TryGetValue(typeof(T), out MapGeneration.FacilityZone zone))
			{
				facilityZone = default(T);
				return false;
			}

			return TryGetZone(zone, out facilityZone);
		}

		internal static bool TryGetZone<T>(MapGeneration.FacilityZone zone, out T facilityZone) where T : FacilityZone
		{
			int zoneId = (int) zone;

			if (Facility._zones.TryGetValue(zoneId, out FacilityZone facZone))
			{
				facilityZone = (T) facZone;
				return true;
			}

			FacilityZone newZone;
			switch (zone)
			{
				case MapGeneration.FacilityZone.Entrance:
					newZone = new EntranceZone();
					break;
				case MapGeneration.FacilityZone.LightContainment:
					newZone = new LightZone();
					break;
				case MapGeneration.FacilityZone.HeavyContainment:
					newZone = new HeavyZone();
					break;
				case MapGeneration.FacilityZone.Surface:
					newZone = new SurfaceZone();
					break;
				case MapGeneration.FacilityZone.Other:
					newZone = new UnknownZone();
					break;
				default:
					Log.Error($"Failed registering zone of type {zone}!");
					facilityZone = default;
					return false;
			}

			Facility._zones.Add(zoneId, newZone);
			facilityZone = (T) newZone;
			return true;
		}

		internal static void RegisterDoors(FacilityRoom room, DoorVariant[] doors)
		{
			foreach (var door in doors)
				RegisterDoor(room, door);
		}

		internal static void RegisterDoor(FacilityRoom room, DoorVariant door)
		{
			switch (door)
			{
				case BreakableDoor br:
					room._doors.Add(door, new FacilityBreakableDoor(room, br));
					break;
				case PryableDoor pd:
					room._doors.Add(door, new FacilityGate(room, pd));
					break;
				default:
					room._doors.Add(door, new FacilityDoor(room, door));
					break;
			}
		}

		internal static void RegisterDoor(DoorSpawnpoint spawnpoint, DoorVariant door)
		{
			var roomIdentity = FindRoomIdentifier(spawnpoint.transform);
			if (roomIdentity == null) return;

			if (!TryGetRoom(roomIdentity, out FacilityRoom room)) return;

			RegisterDoor(room, door);
		}

		internal static RoomIdentifier FindRoomIdentifier(Transform tr)
		{
			if (tr.TryGetComponent<RoomIdentifier>(out RoomIdentifier ri))
				return ri;

			if (tr.parent != null)
				return FindRoomIdentifier(tr.parent);
			return null;
		}

		internal static void Reset()
		{
			_zones.Clear();
		}

		/// <summary>
		/// Gets all rooms in facility.
		/// </summary>
		public static List<FacilityRoom> Rooms => _zones.Values.SelectMany(x => x.GetRooms()).ToList();
		
		/// <summary>
		/// Gets all doors in facility.
		/// </summary>
		public static List<FacilityDoor> Doors => Rooms.SelectMany(x => x._doors.Values).ToList();

		/// <summary>
		/// Turns on all lights in facility.
		/// </summary>
		public static void TurnOnAllLights()
		{
			
		}

		/// <summary>
		/// Turns off all lights in facility.
		/// </summary>
		public static void TurnOffAllLights()
		{
		}
	}
}
