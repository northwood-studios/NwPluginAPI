using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information after a player is pressing a hotkey.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerUseHotkey"/>.</remarks>
	/// </summary>
	public class UsingHotkeyEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingHotkeyEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="hotkey"></param>
		/// <param name="clientsideItem"></param>
		public UsingHotkeyEventArgs(IPlayer player, ActionName hotkey, ushort clientsideItem)
		{
			Player = (Core.Player)player;
			Hotkey = hotkey;
			ItemDesired = clientsideItem;
		}

		/// <summary>
		/// Gets the player who is pressing a hotkey.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the pressed hotkey.
		/// </summary>
		public ActionName Hotkey { get; }

		/// <summary>
		/// Get or set the item to be selected.
		/// <remarks>This is a item serial.</remarks>
		/// </summary>
		public ushort ItemDesired { get; set; }
	}
}