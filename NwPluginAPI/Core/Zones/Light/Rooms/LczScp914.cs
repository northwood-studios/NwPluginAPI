namespace PluginAPI.Core.Zones.Light.Rooms
{
	using Interactables.Interobjects;
	using MapGeneration;
	using PluginAPI.Core;
	using PluginAPI.Core.Zones;
	using PluginAPI.Core.Zones.Light;
	using Scp914;
	using UnityEngine;

	public class LczScp914 : LczRoom
	{
		internal static LczScp914 Instance;

		public static RoomLight RoomLights => Instance.Lights;

		public static RoomIdentifier RoomIdentifier => Instance.Identifier;

		public static PryableDoor Gate => null;

		/// <summary>
		/// Gets the intake chamber <see cref="Transform"/>.
		/// </summary>
		public static Transform IntakeChamber => Server.Instance.GetComponent<Scp914Controller>().IntakeChamber;

		/// <summary>
		/// Gets the output chamber <see cref="Transform"/>.
		/// </summary>
		public static Transform OutputChamber => Server.Instance.GetComponent<Scp914Controller>().OutputChamber;

		/// <summary>
		/// Starts SCP-914 refining process.
		/// </summary>
		public static void Start() => Server.Instance.GetComponent<Scp914Controller>().ServerInteract(Server.Instance.ReferenceHub, (byte)Scp914InteractCode.Activate);

		/// <summary>
		/// Constructor for SCP 914.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public LczScp914(LightZone zone, RoomIdentifier room) : base(zone, room) { }
	}
}
