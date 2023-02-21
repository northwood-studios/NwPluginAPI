namespace PluginAPI.Core
{
	using InventorySystem.Configs;

	/// <summary>
	/// Player-related extensions.
	/// </summary>
	public static class PlayerExtensions
	{
		/// <summary>
		/// Gets ammo limit for certain item type.
		/// </summary>
		/// <param name="type">The type of item.</param>
		/// <returns>Maximum amount of ammo which player can have.</returns>
		public static int GetAmmoLimit(this Player plr, ItemType type) => InventoryLimits.GetAmmoLimit(type, plr.ReferenceHub);

		/// <summary>
		/// Gets maximum amount of items which certain category can give including armor west on player.
		/// </summary>
		/// <param name="category">The item category.</param>
		/// <returns>Maximum amount of items which player can hold.</returns>
		public static int GetCategoryLimit(this Player plr, ItemCategory category) => InventoryLimits.GetCategoryLimit(category, plr.ReferenceHub);
		/// <summary>
		/// Get whether the player holds the item of the specified Serial
		/// </summary>
		/// <param name="serialId">the Serial to check.</param>
		/// <returns>Whether the player holds the item of the specified Serial or not.</returns>
		public static bool HaveItem(this Player plr, ushort serialId){
			return plr.Items.Any(item => item.ItemSerial == serialId);
		}
		/// <summary>
		/// Get whether the player holds the item of the specified itemType
		/// </summary>
		/// <param name="itemType">the itemType to check.</param>
		/// <returns>Whether the player holds the item of the specified itemType or not.</returns>
		public static bool HaveItem(this Player plr, ItemType itemType){
			return plr.Items.Any(item => item.ItemTypeId == itemType);
		}
		/// <summary>
		/// Get the number of items of the specified Itemtype held by the player
		/// </summary>
		/// <param name="itemType">the itemType to check.</param>
		/// <returns>Holds the number of items of the specified itemtype.</returns>
		public static int CountItem(this Player plr, ItemType itemType){
			return plr.Items.Count(item => item.ItemTypeId == itemType);
		}
	}
}
