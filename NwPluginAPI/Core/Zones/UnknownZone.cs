using MapGeneration;
using PluginAPI.Core.Doors;
using System.Collections.Generic;
using System.Linq;

namespace PluginAPI.Core.Zones
{
	/// <summary>
	/// Represents a unknown zone in facility.
	/// </summary>
	public class UnknownZone : FacilityZone
	{
		internal static UnknownZone Instance;
		internal Dictionary<RoomIdentifier, FacilityRoom> _rooms = new Dictionary<RoomIdentifier, FacilityRoom>();

		/// <inheritdoc/>
		public override MapGeneration.FacilityZone ZoneType { get; } = MapGeneration.FacilityZone.Other;

		/// <inheritdoc/>
		public override List<T> GetRooms<T>() => _rooms.Values.Cast<T>().ToList();

		/// <summary>
		/// Gets all rooms in unknown zone.
		/// </summary>
		public static List<FacilityRoom> Rooms => Instance._rooms.Values.ToList();

		/// <summary>
		/// Gets all doors in unknown zone.
		/// </summary>
		public static List<FacilityDoor> Doors => Rooms.SelectMany(x => x._doors.Values).ToList();

		/// <inheritdoc/>
		public override bool TryGetRoom(RoomIdentifier roomIdentity, out FacilityRoom room)
		{
			FacilityRoom facilityRoom = null;
			if (_rooms.TryGetValue(roomIdentity, out facilityRoom))
			{
				room = facilityRoom;
				return true;
			}

			switch (roomIdentity.Name)
			{
				default:
					facilityRoom = new FacilityRoom(this, roomIdentity);
					break;
			}

			_rooms.Add(roomIdentity, facilityRoom);
			room = facilityRoom;
			return true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnknownZone"/> class.
		/// </summary>
		public UnknownZone() => Instance = this;
	}
}