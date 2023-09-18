namespace PluginAPI.Core.Zones.Heavy.Rooms
{
	using Core;
	using Heavy;
	using MapGeneration;
	using Zones;

	/// <summary>
	/// Represents SCP-049's room.
	/// </summary>
	public class HczScp049 : HczRoom
	{
		/// <summary>
		/// The <see cref="HczRoom"/> instance.
		/// </summary>
		internal static HczScp049 Instance;

		/// <summary>
		/// Gets the <see cref="HczScp049"/>'s lights.
		/// </summary>
		public static RoomLight RoomLights => Instance.Lights;

		/// <summary>
		/// Gets the <see cref="HczScp049"/>'s <see cref="MapGeneration.RoomIdentifier"/>.
		/// </summary>
		public static RoomIdentifier RoomIdentifier => Instance.Identifier;

		/// <summary>
		/// Initializes a new instance of the <see cref="HczScp049"/> class.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public HczScp049(HeavyZone zone, RoomIdentifier room) : base(zone, room)
		{
			Instance = this;
		}
	}
}