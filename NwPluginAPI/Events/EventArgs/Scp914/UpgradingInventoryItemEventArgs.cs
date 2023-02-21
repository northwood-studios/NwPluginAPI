using InventorySystem.Items;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Items;
using PluginAPI.Enums;
using Scp914;

namespace PluginAPI.Events.EventArgs.Scp914
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp914UpgradeInventory"/>.
	/// </summary>
	public class UpgradingInventoryItemEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UpgradingInventoryItemEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="item"></param>
		/// <param name="knobSetting"></param>
		public UpgradingInventoryItemEventArgs(IPlayer player, ItemBase item, Scp914KnobSetting knobSetting)
		{
			Player = (Core.Player)player;
			Item = Item.GetOrAdd<Item>(item);
			KnobSetting = knobSetting;
		}

		/// <summary>
		/// Gets player who owns the item be upgraded.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the item be upgraded.
		/// </summary>
		public Item Item { get; }

		/// <summary>
		/// Get or set SCP-914 <see cref="Scp914KnobSetting"/> at the moment of upgrading this item.
		/// </summary>
		public Scp914KnobSetting KnobSetting { get; set; }
	}
}