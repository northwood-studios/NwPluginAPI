using InventorySystem.Items;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerToggleFlashlight"/>.
	/// </summary>
	public class TogglingFlashlightEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TogglingFlashlightEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="item"></param>
		/// <param name="newState"></param>
		public TogglingFlashlightEventArgs(IPlayer player, ItemBase item, bool newState)
		{
			Player = (Core.Player)player;
			Flashlight = item;
			NewState = newState;
		}

		/// <summary>
		/// Gets the player who's toggling the flashlight.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the flashlight being toggled.
		/// </summary>
		public ItemBase Flashlight { get; }

		/// <summary>
		/// Get or set the new flashlight state.
		/// </summary>
		public bool NewState { get; set; }
	}
}