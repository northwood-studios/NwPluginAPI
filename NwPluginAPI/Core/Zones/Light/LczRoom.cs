namespace PluginAPI.Core.Zones.Light
{
	using MapGeneration;
	using Zones;

	public class LczRoom : FacilityRoom
	{
		/// <summary>
		/// The zone the room is in.
		/// </summary>
		public new readonly LightZone Zone;

		/// <summary>
		/// Initializes a new instance of the <see cref="LczRoom"/> class.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public LczRoom(LightZone zone, RoomIdentifier room) : base(zone, room) { }
	}
}