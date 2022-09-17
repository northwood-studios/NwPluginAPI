namespace PluginAPI.Core.Zones.Pocket
{
	using MapGeneration;
	using Zones;
	using System.Collections.Generic;
	using System.Linq;

	public class PocketDimension : FacilityRoom
	{
		public new readonly UnknownZone Zone;

		internal PocketDimensionGenerator _pocketDim;
		internal List<PocketDimensionTeleport> _teleports = new List<PocketDimensionTeleport>();

		public IEnumerable<PocketDimensionTeleport> Teleports => _teleports;

		public static PocketDimensionLogic Logic { get; set; }

		public static bool IsAccesable { get; set; } = true;

		public void ShuffleTeleports()
		{
			_pocketDim.GenerateRandom();
		}

		/// <summary>
		/// Constructor for pocket dimension room.
		/// </summary>
		/// <param name="zone">The zone type.</param>
		/// <param name="room">The room identifier.</param>
		public PocketDimension(UnknownZone zone, RoomIdentifier room) : base(zone, room)
		{
			_pocketDim = Server.Instance.GetComponent<PocketDimensionGenerator>(true);
			_teleports = UnityEngine.Object.FindObjectsOfType<PocketDimensionTeleport>().ToList();
		}
	}
}
