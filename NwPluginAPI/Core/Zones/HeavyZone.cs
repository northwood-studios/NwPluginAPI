namespace PluginAPI.Core.Zones
{
	using MapGeneration;
	using Doors;
	using Heavy;
	using Heavy.Rooms;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents the heavy containment zone.
	/// </summary>
	public class HeavyZone : FacilityZone
	{
		internal static HeavyZone Instance;
		internal Dictionary<RoomIdentifier, HczRoom> _rooms = new Dictionary<RoomIdentifier, HczRoom>();

		/// <inheritdoc/>
		public override MapGeneration.FacilityZone ZoneType { get; } = MapGeneration.FacilityZone.HeavyContainment;

		/// <inheritdoc/>
		public override List<T> GetRooms<T>() => _rooms.Values.Cast<T>().ToList();

		/// <summary>
		/// Gets all rooms in heavy zone.
		/// </summary>
		public static List<HczRoom> Rooms => Instance._rooms.Values.ToList();

		/// <summary>
		/// Gets all doors in heavy zone.
		/// </summary>
		public static List<FacilityDoor> Doors => Rooms.SelectMany(x => x._doors.Values).ToList();

		/// <inheritdoc/>
		public override bool TryGetRoom(RoomIdentifier roomIdentity, out FacilityRoom room)
		{
			HczRoom hczRoom = null;
			if (_rooms.TryGetValue(roomIdentity, out hczRoom))
			{
				room = hczRoom;
				return true;
			}

			switch (roomIdentity.Name)
			{
				case RoomName.Hcz049:
					hczRoom = new HczScp049(this, roomIdentity);
					break;
				default:
					hczRoom = new HczRoom(this, roomIdentity);
					break;
			}

			_rooms.Add(roomIdentity, hczRoom);
			room = hczRoom;
			return true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HeavyZone"/> class.
		/// </summary>
		public HeavyZone() => Instance = this;
	}
}