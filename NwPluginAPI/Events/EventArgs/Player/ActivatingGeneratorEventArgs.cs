using MapGeneration.Distributors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerActivateGenerator"/>.
	/// </summary>
	public class ActivatingGeneratorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ActivatingGeneratorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="generator"></param>
		public ActivatingGeneratorEventArgs(IPlayer player, Scp079Generator generator)
		{
			Player = (Core.Player)player;
			Generator = Generator.Get(generator);
		}

		/// <summary>
		/// Gets player activating generator.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get the generator which is being activated.
		/// </summary>
		public Generator Generator { get; }
	}
}