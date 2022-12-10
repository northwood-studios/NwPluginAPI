namespace PluginAPI.Enums
{
	/// <summary>
	/// Represents load priorities for plugins.
	/// </summary>
	public enum LoadPriority : byte
	{
		Highest = 64,
		High = 96,
		Medium = 128,
		Low = 160,
		Lowest = 192
	}
}
