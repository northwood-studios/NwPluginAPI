using MapGeneration.Distributors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerCloseGenerator "/>.
	/// </summary>
	public class ClosingGeneratorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ClosingGeneratorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="generator"></param>
		public ClosingGeneratorEventArgs(IPlayer player, Scp079Generator generator)
		{
			Player = (Core.Player)player;
			Generator = Generator.Get(generator);
		}

		/// <summary>
		/// Gets player closing a generator.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets generator closed.
		/// </summary>
		public Generator Generator { get; }
	}
}