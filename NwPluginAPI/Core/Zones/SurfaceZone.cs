namespace PluginAPI.Core.Zones
{
	using MapGeneration;
	using Doors;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents the surface zone.
	/// </summary>
	public class SurfaceZone : FacilityZone
	{
		internal static SurfaceZone Instance;
		internal Dictionary<RoomIdentifier, Surface> _rooms = new Dictionary<RoomIdentifier, Surface>();

		/// <inheritdoc/>
		public override MapGeneration.FacilityZone ZoneType { get; } = MapGeneration.FacilityZone.Surface;

		/// <inheritdoc/>
		public override List<T> GetRooms<T>() => _rooms.Values.Cast<T>().ToList();

		/// <summary>
		/// Gets all rooms in surface zone.
		/// </summary>
		public static List<Surface> Rooms => Instance._rooms.Values.ToList();

		/// <summary>
		/// Gets all doors in surface zone.
		/// </summary>
		public static List<FacilityDoor> Doors => Rooms.SelectMany(x => x._doors.Values).ToList();

		/// <inheritdoc/>
		public override bool TryGetRoom(RoomIdentifier roomIdentity, out FacilityRoom room)
		{
			Surface surfaceRoom = null;
			if (_rooms.TryGetValue(roomIdentity, out surfaceRoom))
			{
				room = surfaceRoom;
				return true;
			}

			switch (roomIdentity.Name)
			{
				default:
					surfaceRoom = new Surface(this, roomIdentity);
					break;
			}

			_rooms.Add(roomIdentity, surfaceRoom);
			room = surfaceRoom;
			return true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SurfaceZone"/> class.
		/// </summary>
		public SurfaceZone() => Instance = this;
	}
}
