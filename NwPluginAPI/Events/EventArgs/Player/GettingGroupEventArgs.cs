using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before assigning a user group to a player.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerGetGroup"/>.
	/// </remarks>
	/// </summary>
	public class GettingGroupEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="GettingGroupEventArgs"/>.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="group"></param>
		public GettingGroupEventArgs(string userId, UserGroup group)
		{
			UserId = userId;
			Group = group;
		}

		/// <summary>
		/// Gets the player user id who is checking.
		/// </summary>
		public string UserId { get; }

		/// <summary>
		/// Get or set the user group what is going to be assigned to the player.
		/// </summary>
		public UserGroup Group { get; set; }
	}
}