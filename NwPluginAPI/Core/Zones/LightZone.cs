namespace PluginAPI.Core.Zones
{
	using Doors;
	using Light;
	using Light.Rooms;
	using LightContainmentZoneDecontamination;
	using MapGeneration;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents the light containment zone.
	/// </summary>
	public class LightZone : FacilityZone
	{
		internal static LightZone Instance;
		internal Dictionary<RoomIdentifier, LczRoom> _rooms = new Dictionary<RoomIdentifier, LczRoom>();

		/// <inheritdoc/>
		public override MapGeneration.FacilityZone ZoneType { get; } = MapGeneration.FacilityZone.LightContainment;

		/// <inheritdoc/>
		public override List<T> GetRooms<T>() => _rooms.Values.Cast<T>().ToList();

		/// <summary>
		/// Gets all rooms in light zone.
		/// </summary>
		public static List<LczRoom> Rooms => Instance._rooms.Values.ToList();

		/// <summary>
		/// Gets all doors in surface zone.
		/// </summary>
		public static List<FacilityDoor> Doors => Rooms.SelectMany(x => x._doors.Values).ToList();

		/// <inheritdoc/>
		public override bool TryGetRoom(RoomIdentifier roomIdentity, out FacilityRoom room)
		{
			LczRoom lczRoom = null;
			if (_rooms.TryGetValue(roomIdentity, out lczRoom))
			{
				room = lczRoom;
				return true;
			}

			switch (roomIdentity.Name)
			{
				case RoomName.Lcz914:
					lczRoom = new LczScp914(this, roomIdentity);
					break;
				default:
					lczRoom = new LczRoom(this, roomIdentity);
					break;
			}

			_rooms.Add(roomIdentity, lczRoom);
			room = lczRoom;
			return true;
		}

		/// <summary>
		/// Checks whether or not the zone has already been decontaminated.
		/// </summary>
		public static bool IsDecontaminated => false; // DecontaminationController.Singleton._stopUpdating && !DecontaminationController.Singleton.disableDecontamination;

		/// <summary>
		/// Starts decontamination.
		/// </summary>
		public static void StartDecontamination()
		{
			//DecontaminationController.Singleton.FinishDecontamination();
			DecontaminationController.Singleton.RoundStartTime = -1f;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LightZone"/> class.
		/// </summary>
		public LightZone() => Instance = this;
	}
}