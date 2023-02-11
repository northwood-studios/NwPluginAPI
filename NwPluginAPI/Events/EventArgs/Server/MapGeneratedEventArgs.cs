using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.MapGenerated"/>.
	/// </summary>
	public class MapGeneratedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="MapGeneratedEventArgs"/>.
		/// </summary>
		/// <param name="seed"></param>
		public MapGeneratedEventArgs(int seed)
		{
			Seed = seed;
		}

		/// <summary>
		/// Gets map seed.
		/// </summary>
		public int Seed { get; }
	}
}