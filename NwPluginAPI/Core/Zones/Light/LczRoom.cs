namespace PluginAPI.Core.Zones.Light
{
	using MapGeneration;
	using Zones;

	public class LczRoom : FacilityRoom
	{
		public new readonly LightZone Zone;

		/// <summary>
		/// Constructor for light zone room.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public LczRoom(LightZone zone, RoomIdentifier room) : base(zone, room) { }
	}
}
