namespace PluginAPI.Core.Zones.Pocket
{
	using MapGeneration;
	using Zones;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents the pocket dimension.
	/// </summary>
	public class PocketDimension : FacilityRoom
	{
		/// <summary>
		/// The zone the pocket dimension is in.
		/// </summary>
		public new readonly UnknownZone Zone;

		internal PocketDimensionGenerator _pocketDim;
		internal List<PocketDimensionTeleport> _teleports = new List<PocketDimensionTeleport>();

		/// <summary>
		/// Gets the pocket dimension teleports.
		/// </summary>
		public IEnumerable<PocketDimensionTeleport> Teleports => _teleports;

		/// <summary>
		/// Gets the pocket dimension's <see cref="PocketDimensionLogic"/>.
		/// </summary>
		public static PocketDimensionLogic Logic { get; set; }

		/// <summary>
		/// Gets or sets whether or not the pocket dimension is accessible.
		/// </summary>
		public static bool IsAccessible { get; set; } = true;

		/// <summary>
		/// Shuffles the pocket dimension's teleports.
		/// </summary>
		public void ShuffleTeleports()
		{
			_pocketDim.GenerateRandom();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PocketDimension"/> class.
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
