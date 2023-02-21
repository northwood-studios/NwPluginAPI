using InventorySystem.Items.Usables;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerCancelUsingItem"/>.
	/// </summary>
	public class CancellingItemUseEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CancellingItemUseEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="item"></param>
		public CancellingItemUseEventArgs(IPlayer player, UsableItem item)
		{
			Player = (Core.Player)player;
			Item = item;
		}

		/// <summary>
		/// Gets player who trigger this action.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets <see cref="UsableItem"/> item.
		/// </summary>
		public UsableItem Item { get; }
	}
}