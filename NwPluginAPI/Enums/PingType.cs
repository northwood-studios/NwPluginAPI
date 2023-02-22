namespace PluginAPI.Enums
{
	/// <summary>
	/// Type of pings for SCP-079
	/// </summary>
	public enum PingType : byte
	{
		/// <summary>
		/// Generator ping.
		/// </summary>
		Generator,

		/// <summary>
		/// Projectile ping.
		/// </summary>
		Projectile,

		/// <summary>
		/// Micro-HID ping.
		/// </summary>
		MicroHid,

		/// <summary>
		/// Human ping.
		/// </summary>
		Human,

		/// <summary>
		/// Elevator ping.
		/// </summary>
		Elevator,

		/// <summary>
		/// Door ping.
		/// </summary>
		Door,

		/// <summary>
		/// General ping.
		/// </summary>
		Default,
	}
}