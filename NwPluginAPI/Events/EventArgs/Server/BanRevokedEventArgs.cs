using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// Contains all the information after a ban is removed and deleted from the files.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.BanRevoked"/>.
	/// </remarks>
	/// </summary>
	public class BanRevokedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="BanRevokedEventArgs"/>.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="banType"></param>
		public BanRevokedEventArgs(string userId, BanHandler.BanType banType)
		{
			UserId = userId;
			BanType = banType;
		}

		/// <summary>
		/// Get the user id of the player being unbanned.
		/// </summary>
		public string UserId { get; }

		/// <summary>
		/// Gets the unban type.
		/// </summary>
		public BanHandler.BanType BanType { get; }
	}
}