using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information when checking if a player has a reserved slot.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerCheckReservedSlot"/>.</remarks>
	/// </summary>
	public class ReservedSlotsCheckEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UnMuteEventArgs"/>.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="hasReservedSlot"></param>
		public ReservedSlotsCheckEventArgs(string userId, bool hasReservedSlot)
		{
			UserId = userId;
			HasReservedSlot = hasReservedSlot;
		}

		/// <summary>
		///  Gets the UserID of the player that is being checked.
		/// </summary>
		public string UserId { get; }

		/// <summary>
		/// Gets a value indicating if the player has reserved slot in base game system.
		/// </summary>
		public bool HasReservedSlot { get; }
	}
}