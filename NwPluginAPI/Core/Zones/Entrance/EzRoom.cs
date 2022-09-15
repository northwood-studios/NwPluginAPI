namespace PluginAPI.Core.Zones.Entrance
{
	using MapGeneration;
	using PluginAPI.Core.Zones;

	public class EzRoom : FacilityRoom
	{
		public readonly new EntranceZone Zone;

		/// <summary>
		/// Constructor for entrance zone room.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public EzRoom(EntranceZone zone, RoomIdentifier room) : base(zone, room) { }
	}
}
