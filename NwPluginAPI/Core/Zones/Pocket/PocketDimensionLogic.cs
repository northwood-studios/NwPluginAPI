namespace PluginAPI.Core.Zones.Pocket
{
	using static PocketDimensionTeleport;

	/// <summary>
	/// Handles the Pocket Dimension's logic.
	/// </summary>
	public class PocketDimensionLogic
	{
		/// <summary>
		/// The pocket dimension.
		/// </summary>
		public readonly PocketDimension PocketDimension;

		public virtual bool OnPlayerEnteredPortal(Player plr, PDTeleportType type)
		{
			return true;
		}

		public virtual bool OnPlayerEnteredPD(Player plr, Player movedBy)
		{
			return true;
		}

		public virtual void OnDestroy() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PocketDimensionLogic"/> class.
		/// </summary>
		/// <param name="pd">The pocket dimension.</param>
		public PocketDimensionLogic(PocketDimension pd)
		{
			PocketDimension = pd;
		}
	}
}