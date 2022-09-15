namespace PluginAPI.Core.Zones.Pocket
{
	using static PocketDimensionTeleport;

	public class PocketDimensionLogic
	{
		public readonly PocketDimension PocketDimension;

		public virtual bool OnPlayerEnteredPortal(Player plr, PDTeleportType type)
		{
			return true;
		}

		public virtual bool OnPlayerEnteredPD(Player plr, Player movedBy)
		{
			return true;
		}

		public virtual void OnDestroy()
		{

		}

		public PocketDimensionLogic(PocketDimension pd)
		{
			PocketDimension = pd;
		}
	}
}
