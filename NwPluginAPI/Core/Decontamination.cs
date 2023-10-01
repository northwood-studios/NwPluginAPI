namespace PluginAPI.Core
{
	using LightContainmentZoneDecontamination;
	using static LightContainmentZoneDecontamination.DecontaminationController;

	/// <summary>
	/// Manages the <see cref="DecontaminationController"/>.
	/// </summary>
	public static class Decontamination
	{
		/// <summary>
		/// Gets the <see cref="DecontaminationController"/> singleton.
		/// </summary>
		public static readonly DecontaminationController Singleton = DecontaminationController.Singleton;

		/// <summary>
		/// Gets if Light Containment Zone is currently being decontaminated.
		/// </summary>
		public static bool IsDecontamination => Singleton.IsDecontaminating;

		/// <summary>
		/// Gets or sets the <see cref="DecontaminationStatus"/>.
		/// </summary>
		public static DecontaminationStatus Status
		{
			get => Singleton.DecontaminationOverride;
			set => Singleton.NetworkDecontaminationOverride = value;
		}

		/// <summary>
		/// Forces Light Containment Zone to be decontaminated.
		/// </summary>
		public static void ForceDecontamination() => Singleton.ForceDecontamination();
	}
}
