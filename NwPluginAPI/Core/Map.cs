using MapGeneration;
using System.Collections.Generic;
using System.Drawing;
using LightContainmentZoneDecontamination;
using MapGeneration.Distributors;
using PlayerRoles.PlayableScps.Scp079.Cameras;
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
		/// Get the current cameras of the map.
		/// </summary>
		public static IReadOnlyCollection<Scp079Camera> Scp079Cameras => _cameras.AsReadOnly();

		/// <summary>
		/// Get the current pocket dimensions teleports of the map.
		/// </summary>
		public static IReadOnlyCollection<PocketDimensionTeleport> PocketDimensionTeleports => _teleports.AsReadOnly();

		/// <summary>
		/// Get the current lockers of the map.
		/// </summary>
		public static IReadOnlyCollection<Locker> Lockers => _lockers.AsReadOnly();

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
		/// None is by default, set status to force dont actually force decontamination for dat use <see cref="ForceDecontamination"/>.
		/// </remarks>
		/// </summary>
		public static DecontaminationController.DecontaminationStatus DecontaminationStatus
		{
			get => DecontaminationController.Singleton.DecontaminationOverride;
			set => DecontaminationController.Singleton.DecontaminationOverride = value;
		}

		#region Facility rooms

		#region  Light Flicker

		/// <summary>
		/// Turns off the lights in the specified zone, for a period of time.
		/// </summary>
		/// <param name="duration">The duration in seconds of the blackout</param>
		/// <param name="zone">The area where the lights are off</param>
		public static void FlickerLights(float duration, FacilityZone zone)
		{

			foreach (var controller in FlickerableLightController.Instances)
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
			foreach (var controller in FlickerableLightController.Instances)
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
			foreach (var controller in FlickerableLightController.Instances)
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
			foreach (var controller in FlickerableLightController.Instances)
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
		/// <param name="intensity">Light intensity</param>
		public static void ChangeColorOfAllLights(Color color, float intensity = 0)
		{
			foreach (var controller in FlickerableLightController.Instances)
			{
				controller.Room.ApiRoom.Lights.LightColor = color;
				if (intensity > 0)
					controller.Room.ApiRoom.Lights.LightIntensity = intensity;
			}
		}

		/// <summary>
		/// Changes the color of the lights in a specific zone
		/// </summary>
		public static void ChangeColorOfLights(Color color, FacilityZone zone, float intensity = 0)
		{
			foreach (var controller in FlickerableLightController.Instances)
			{
				if (controller.Room.Zone != zone)
					continue;

				controller.Room.ApiRoom.Lights.LightColor = color;
				if (intensity > 0)
					controller.Room.ApiRoom.Lights.LightIntensity = intensity;
			}
		}

		/// <summary>
		/// Changes the color of the lights in a specific zones
		/// </summary>
		public static void ChangeColorOfLights(Color color, IEnumerable<FacilityZone> zones, float intensity = 0)
		{
			foreach (var facilityZone in zones)
			{
				ChangeColorOfLights(color, facilityZone, intensity);
			}
		}

		#endregion

		#region Restore color facility room

		/// <summary>
		/// Resets the color of all lights to their original color.
		/// </summary>
		public static void ResetColorOfAllLights()
		{
			foreach (var controller in FlickerableLightController.Instances)
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
			foreach (var controller in FlickerableLightController.Instances)
			{
				if (controller.Room.Zone != zone) continue;

				if (controller.Room.ApiRoom.Lights.LightColor != controller.Room.ApiRoom.Lights.DefaultColor)
					controller.Room.ApiRoom.Lights.LightColor = controller.Room.ApiRoom.Lights.DefaultColor;
			}
		}

		#endregion

		#endregion

		#region Internal fields

		internal static List<Scp079Camera> _cameras = new(150); //Idk the exact number of cameras per map.

		internal static List<PocketDimensionTeleport> _teleports = new(8);

		internal static List<Locker> _lockers = new(100);

		#endregion
	}
}