using MapGeneration.Distributors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerUnlockGenerator"/>.
	/// </summary>
	public class UnlockingGeneratorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UnlockingGeneratorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="generator"></param>
		public UnlockingGeneratorEventArgs(IPlayer player, Scp079Generator generator)
		{
			Player = (Core.Player)player;
			Generator = Generator.Get(generator);
		}

		/// <summary>
		/// Gets the player who's unlocking the generator.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the generator that is going to be unlocked.
		/// </summary>
		public Generator Generator { get; }
	}
}