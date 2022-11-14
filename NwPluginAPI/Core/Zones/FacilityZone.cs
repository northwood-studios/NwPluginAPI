namespace PluginAPI.Core.Zones
{
	using MapGeneration;
	using System.Collections.Generic;

	/// <summary>
	/// Represents a zone.
	/// </summary>
	public class FacilityZone
	{
		/// <summary>
		/// Gets all rooms.
		/// </summary>
		/// <returns>List of all rooms.</returns>
		public List<FacilityRoom> GetRooms() => GetRooms<FacilityRoom>();

		/// <summary>
		/// Gets all rooms of specific type.
		/// </summary>
		/// <typeparam name="T">The tyep of rooms.</typeparam>
		/// <returns>List of all rooms.</returns>
		public virtual List<T> GetRooms<T>() where T : FacilityRoom => null;

		/// <summary>
		/// Gets surface room from room identifier.
		/// </summary>
		/// <param name="roomIdentity">The room identifier.</param>
		/// <param name="room">The facility room.</param>
		/// <returns>Whether or not the room was found.</returns>
		public virtual bool TryGetRoom(RoomIdentifier roomIdentity, out FacilityRoom room)
		{
			room = default;
			return false;
		}

		/// <summary>
		/// Gets the zone type.
		/// </summary>
		public virtual MapGeneration.FacilityZone ZoneType { get; }
	}
}
