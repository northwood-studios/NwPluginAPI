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
	}
}
