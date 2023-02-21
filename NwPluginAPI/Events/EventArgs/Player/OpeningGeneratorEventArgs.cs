using MapGeneration.Distributors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerOpenGenerator"/>.
	/// </summary>
	public class OpeningGeneratorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="OpeningGeneratorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="generator"></param>
		public OpeningGeneratorEventArgs(IPlayer player, Scp079Generator generator)
		{
			Player = (Core.Player)player;
			Generator = Generator.Get(generator);
		}

		/// <summary>
		/// Gets the player opening a generator.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the generator that is opening.
		/// </summary>
		public Generator Generator { get; }
	}
}