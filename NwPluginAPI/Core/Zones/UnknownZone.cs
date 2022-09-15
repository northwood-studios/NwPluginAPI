namespace PluginAPI.Core.Zones
{
	/// <summary>
	/// Unknown zone in facility.
	/// </summary>
	public class UnknownZone : FacilityZone
	{
		internal static UnknownZone Instance;

		/// <inheritdoc/>
		public override MapGeneration.FacilityZone ZoneType { get; } = MapGeneration.FacilityZone.Other;
	}
}
