using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// Contains all the information before a ban is updated.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.BanUpdated"/>.
	/// </remarks>
	/// </summary>
	public class BanUpdatingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="BanUpdatingEventArgs"/>.
		/// </summary>
		/// <param name="banDetails"></param>
		/// <param name="type"></param>
		public BanUpdatingEventArgs(BanDetails banDetails, BanHandler.BanType type)
		{
			BanDetails = banDetails;
			BanType = type;
		}

		/// <summary>
		/// Gets the new ban details.
		/// </summary>
		public BanDetails BanDetails { get; }

		/// <summary>
		/// Gets the ban type.
		/// </summary>
		public BanHandler.BanType BanType { get; }
	}
}