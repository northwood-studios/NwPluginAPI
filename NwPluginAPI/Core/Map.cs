using MapGeneration;
using System.Collections.Generic;
using System.Linq;
using Interactables.Interobjects;
using LightContainmentZoneDecontamination;
using MapGeneration.Distributors;
using PlayerRoles.PlayableScps.Scp079.Cameras;
using UnityEngine;
using Color = UnityEngine.Color;

namespace PluginAPI.Core
{
	/// <summary>
	/// A set of tools to easily handle the in-game map.
	/// </summary>
	public static class Map
	{
		/// <summary>
		/// Gets the current seed of the map.
		/// </summary>
		public static int Seed => MapGeneration.SeedSynchronizer.Seed;

		/// <summary>
		/// Get the current rooms of the map.
		/// </summary>
		public static IReadOnlyCollection<RoomIdentifier> Rooms => RoomIdentifier.RoomsByCoordinates.Values;

		/// <summary>
		/// Get the current <see cref="Scp079Camera"/>s of the map.
		/// </summary>
		/// <remarks>
		/// Please avoid calling this method several times, I recommend you to save the values in a variable in your code and update it every time a map is generated again.
		/// </remarks>
		public static IReadOnlyCollection<Scp079Camera> Cameras => Object.FindObjectsOfType<Scp079Camera>();

		/// <summary>
		/// Get the current pocket dimensions teleports of the map.
		/// </summary>
		/// <remarks>
		/// Please avoid calling this method several times, I recommend you to save the values in a variable in your code and update it every time a map is generated again.
		/// </remarks>
		public static IReadOnlyCollection<PocketDimensionTeleport> PocketDimensionTeleports => Object.FindObjectsOfType<PocketDimensionTeleport>();

		/// <summary>
		/// Get the current lockers of the map.
		/// </summary>
		/// <remarks>
		/// Please avoid calling this method several times, I recommend you to save the values in a variable in your code and update it every time a map is generated again.
		/// </remarks>
		public static IReadOnlyCollection<Locker> Lockers => Object.FindObjectsOfType<Locker>();

		/// <summary>
		/// Get the current elevators of the map.
		/// </summary>
		/// <remarks>
		/// Please avoid calling this method several times, I recommend you to save the values in a variable in your code and update it every time a map is generated again.
		/// </remarks>
		public static IReadOnlyCollection<ElevatorChamber> Elevators => Object.FindObjectsOfType<ElevatorChamber>();

		/// <summary>
		/// Get the current tesla gates of the map.
		/// </summary>
		/// <remarks>
		/// Please avoid calling this method several times, I recommend you to save the values in a variable in your code and update it every time a map is generated again.
		/// </remarks>
		public static IReadOnlyCollection<TeslaGate> TeslaGates => TeslaGate.AllGates;

		/// <summary>
		/// Get the current generators of the map.
		/// </summary>
		/// <remarks>
		/// Please avoid calling this method several times, I recommend you to save the values in a variable in your code and update it every time a map is generated again.
		/// </remarks>
		public static IReadOnlyCollection<Scp079Generator> Generators => Object.FindObjectsOfType<Scp079Generator>();

		/// <summary>
		/// Broadcast a message to all <see cref="Player">players</see>.
		/// </summary>
		/// <param name="duration">The duration in seconds of the broadcast</param>
		/// <param name="message">The message that will broadcast</param>
		/// <param name="flag">The broadcast flag type</param>
		/// <param name="clearPrevius">Clear all player broadcast before sending this broadcast ?</param>
		public static void Broadcast(ushort duration, string message, global::Broadcast.BroadcastFlags flag = global::Broadcast.BroadcastFlags.Normal, bool clearPrevius = false)
		{
			if (clearPrevius)
				ClearBroadcasts();

			Server.Broadcast.RpcAddElement(message, duration, flag);
		}

		/// <summary>
		/// Clear all <see cref="Player"> players</see> broadcast.
		/// </summary>
		public static void ClearBroadcasts() => Server.Broadcast.RpcClearElements();

		/// <summary>
		/// Force LCZ decontamination.
		/// </summary>
		public static void ForceDecontamination() => DecontaminationController.Singleton.ForceDecontamination();

		/// <summary>
		/// Get or set LCZ decontamination status.
		/// <remarks>
		/// None is by default, set status to force dont actually force decontamination for that use <see cref="Map.ForceDecontamination"/>.
		/// </remarks>
		/// </summary>
		public static DecontaminationController.DecontaminationStatus DecontaminationStatus
		{
			get => DecontaminationController.Singleton.DecontaminationOverride;
			set => DecontaminationController.Singleton.DecontaminationOverride = value;
		}

		#region Facility rooms tools

		#region GetRandomRoom

		/// <summary>
		/// Get a random room from the specified zone.
		/// </summary>
		/// <remarks>
		/// Can be null if no room is found.
		/// </remarks>
		/// <returns><see cref="RoomIdentifier"/></returns>
		public static RoomIdentifier GetRandomRoom(FacilityZone zone)
		{
			var rooms = Rooms.Where(r => r.Zone == zone);
			return rooms.Any() ? rooms.ElementAtOrDefault(Random.Range(0, rooms.Count())) : null;
		}

		#endregion

		#region  Light Flicker

		/// <summary>
		/// Turns off the lights in the specified zone, for a period of time.
		/// </summary>
		/// <param name="duration">The duration in seconds of the blackout</param>
		/// <param name="zone">The area where the lights are off</param>
		public static void FlickerLights(float duration, FacilityZone zone)
		{

			foreach (var controller in RoomLightController.Instances)
			{
				if(controller.Room.Zone == zone)
					controller.ServerFlickerLights(duration);
			}
		}

		/// <summary>
		/// Turns off the lights in the specified zones, for a period of time.
		/// </summary>
		/// <param name="duration">The duration in seconds of the blackout</param>
		/// <param name="zones">The areas where the lights will be turned off</param>
		public static void FlickerLights(float duration, IEnumerable<FacilityZone> zones)
		{
			foreach (var facilityzones in zones)
			{
				FlickerLights(duration, facilityzones);
			}
		}

		/// <summary>
		/// Turns off all lights on the map, for a specified time.
		/// </summary>
		/// <param name="duration">The duration in seconds of the blackout</param>
		public static void FlickerAllLights(float duration)
		{
			foreach (var controller in RoomLightController.Instances)
			{
				controller.ServerFlickerLights(duration);
			}
		}

		#endregion

		#region Turn On Lights

		/// <summary>
		/// Turn on all the lights on the map
		/// </summary>
		public static void TurnOnAllLights()
		{
			foreach (var controller in RoomLightController.Instances)
			{
				controller.ServerFlickerLights(1);
			}
		}

		/// <summary>
		/// Turns on all the lights in a specified zone.
		/// </summary>
		/// <param name="zone">The area where the lights off will be switched on</param>
		public static void TurnOnLights(FacilityZone zone)
		{
			foreach (var controller in RoomLightController.Instances)
			{
				if (controller.Room.Zone == zone)
					controller.ServerFlickerLights(1);
			}
		}

		/// <summary>
		/// Turns on the lights in the specified areas
		/// </summary>
		/// <param name="zones">The areas where the lights off will be switched on</param>
		public static void TurnOnLights(IEnumerable<FacilityZone> zones)
		{
			foreach (var facilityzone in zones)
			{
				TurnOnLights(facilityzone);
			}
		}

		#endregion

		#region Change color facility rooms

		/// <summary>
		/// Changes the color of all lights on the map
		/// </summary>
		/// <param name="color"><see cref="Color"/> of the lights</param>
		public static void ChangeColorOfAllLights(Color color)
		{
			foreach (var controller in RoomLightController.Instances)
			{
				controller.Room.ApiRoom.Lights.LightColor = color;
			}
		}

		/// <summary>
		/// Changes the color of the lights in a specific zone
		/// </summary>
		public static void ChangeColorOfLights(Color color, FacilityZone zone)
		{
			foreach (var controller in RoomLightController.Instances)
			{
				if (controller.Room.Zone != zone)
					continue;

				controller.Room.ApiRoom.Lights.LightColor = color;
			}
		}

		/// <summary>
		/// Changes the color of the lights in a specific zones
		/// </summary>
		public static void ChangeColorOfLights(Color color, IEnumerable<FacilityZone> zones)
		{
			foreach (var facilityZone in zones)
			{
				ChangeColorOfLights(color, facilityZone);
			}
		}

		#endregion

		#region Restore color facility room

		/// <summary>
		/// Resets the color of all lights to their original color.
		/// </summary>
		public static void ResetColorOfAllLights()
		{
			foreach (var controller in RoomLightController.Instances)
			{
				if (controller.Room.ApiRoom.Lights.LightColor != controller.Room.ApiRoom.Lights.DefaultColor)
					controller.Room.ApiRoom.Lights.LightColor = controller.Room.ApiRoom.Lights.DefaultColor;
			}
		}

		/// <summary>
		/// Resets the color of the lights to their original color in the specified zone.
		/// </summary>
		/// <param name="zone">Facilty zone</param>
		public static void ResetColorOfLights(FacilityZone zone)
		{
			foreach (var controller in RoomLightController.Instances)
			{
				if (controller.Room.Zone != zone) continue;

				if (controller.Room.ApiRoom.Lights.LightColor != controller.Room.ApiRoom.Lights.DefaultColor)
					controller.Room.ApiRoom.Lights.LightColor = controller.Room.ApiRoom.Lights.DefaultColor;
			}
		}

		#endregion

		#endregion
	}
}