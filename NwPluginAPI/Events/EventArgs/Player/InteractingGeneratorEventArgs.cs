using MapGeneration.Distributors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player interacts with a generator.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerInteractGenerator"/>.
	/// </remarks>
	/// </summary>
	public class InteractingGeneratorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="InteractingGeneratorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="generator"></param>
		/// <param name="generatorColliderId"></param>
		public InteractingGeneratorEventArgs(IPlayer player, Scp079Generator generator,
			Scp079Generator.GeneratorColliderId generatorColliderId)
		{
			Player = (Core.Player)player;
			Generator = Generator.Get(generator);
			ColliderId = generatorColliderId;
		}

		/// <summary>
		/// Gets the player interacting with the generator.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the generator interacted.
		/// </summary>
		public Generator Generator { get; }

		/// <summary>
		/// Gets the generator collider id.
		/// </summary>
		public Scp079Generator.GeneratorColliderId ColliderId { get; }
	}
}