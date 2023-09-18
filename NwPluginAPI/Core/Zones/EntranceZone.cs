namespace PluginAPI.Core.Zones
{
	using Doors;
	using Entrance;
	using MapGeneration;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents the entrance zone.
	/// </summary>
	public class EntranceZone : FacilityZone
	{
		/// <summary>
		/// The <see cref="EntranceZone"/> instance.
		/// </summary>
		internal static EntranceZone Instance;

		internal Dictionary<RoomIdentifier, EzRoom> _rooms = new Dictionary<RoomIdentifier, EzRoom>();

		/// <inheritdoc/>
		public override MapGeneration.FacilityZone ZoneType { get; } = MapGeneration.FacilityZone.Entrance;

		/// <inheritdoc/>
		public override List<T> GetRooms<T>() => _rooms.Values.Cast<T>().ToList();

		/// <summary>
		/// Gets all rooms in entrance zone.
		/// </summary>
		public static List<EzRoom> Rooms => Instance._rooms.Values.ToList();

		/// <summary>
		/// Gets all doors in entrance zone.
		/// </summary>
		public static List<FacilityDoor> Doors => Rooms.SelectMany(x => x._doors.Values).ToList();

		/// <inheritdoc/>
		public override bool TryGetRoom(RoomIdentifier roomIdentity, out FacilityRoom room)
		{
			EzRoom ezRoom = null;
			if (_rooms.TryGetValue(roomIdentity, out ezRoom))
			{
				room = ezRoom;
				return true;
			}

			switch (roomIdentity.Name)
			{
				default:
					ezRoom = new EzRoom(this, roomIdentity);
					break;
			}

			_rooms.Add(roomIdentity, ezRoom);
			room = ezRoom;
			return true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EntranceZone"/> class.
		/// </summary>
		public EntranceZone() => Instance = this;
	}
}