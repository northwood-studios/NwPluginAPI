using MapGeneration.Distributors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDeactivatedGenerator"/>.
	/// </summary>
	public class DeactivatingGeneratorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DeactivatingGeneratorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="generator"></param>
		public DeactivatingGeneratorEventArgs(IPlayer player, Scp079Generator generator)
		{
			Player = (Core.Player)player;
			Generator = Generator.Get(generator);
		}

		/// <summary>
		/// Gets player deactivating a generator.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the generator deactivated.
		/// </summary>
		public Generator Generator { get; }
	}
}