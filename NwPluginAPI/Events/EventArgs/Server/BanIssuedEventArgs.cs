using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// Contains all information after a ban is written to the files
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.BanIssued"/>.
	/// </remarks>
	/// </summary>
	public class BanIssuedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="BanIssuedEventArgs"/>.
		/// </summary>
		/// <param name="banDetails"></param>
		/// <param name="banType"></param>
		public BanIssuedEventArgs(BanDetails banDetails, BanHandler.BanType banType)
		{
			BanDetails = banDetails;
			BanType = banType;
		}

		/// <summary>
		/// Gets the ban details.
		/// </summary>
		public BanDetails BanDetails { get; }

		/// <summary>
		/// Gets the ban type.
		/// </summary>
		public BanHandler.BanType BanType { get; }
	}
}