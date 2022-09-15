namespace PluginAPI.Core.Zones
{
	using MapGeneration;

	public class Surface : FacilityRoom
	{
		public readonly new SurfaceZone Zone;

		/// <summary>
		/// Constructor for surface zone room.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public Surface(SurfaceZone zone, RoomIdentifier room) : base(zone, room) { }
	}
}
