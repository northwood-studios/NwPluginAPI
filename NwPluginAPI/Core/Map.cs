namespace PluginAPI.Core
{
	/// <summary>
	/// A set of tools to easily handle the in-game map.
	/// </summary>
	public static class Map
	{
		/// <summary>
		/// Gets the current seed of the map.
		/// </summary>
		public static int Seed => MapGeneration.SeedSynchronizer.Seed;
	}
}
