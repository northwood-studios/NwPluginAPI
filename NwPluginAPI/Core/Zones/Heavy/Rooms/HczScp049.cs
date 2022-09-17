namespace PluginAPI.Core.Zones.Heavy.Rooms
{
	using MapGeneration;
	using Core;
	using Zones;
	using Heavy;

	public class HczScp049 : HczRoom
	{
		internal static HczScp049 Instance;

		public static RoomLight RoomLights => Instance.Lights;
		public static RoomIdentifier RoomIdentifier => Instance.Identifier;

		/// <summary>
		/// Constructor for SCP 049 room.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public HczScp049(HeavyZone zone, RoomIdentifier room) : base(zone, room)
		{
			Instance = this;
		}
	}
}
