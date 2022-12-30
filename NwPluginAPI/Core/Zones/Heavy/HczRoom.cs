namespace PluginAPI.Core.Zones.Heavy
{
	using MapGeneration;
	using Zones;

	public class HczRoom : FacilityRoom
	{
		public Generator Generator { get; internal set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="HczRoom"/> class.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public HczRoom(HeavyZone zone, RoomIdentifier room) : base(zone, room) { }
	}
}