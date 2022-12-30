namespace PluginAPI.Core.Zones
{
	using MapGeneration;

	/// <summary>
	/// Represents the surface.
	/// </summary>
	public class Surface : FacilityRoom
	{
		/// <summary>
		/// The zone the surface is in.
		/// </summary>
		public new readonly SurfaceZone Zone;

		/// <summary>
		/// Initializes a new instance of the <see cref="Surface"/> class.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public Surface(SurfaceZone zone, RoomIdentifier room) : base(zone, room) { }
	}
}