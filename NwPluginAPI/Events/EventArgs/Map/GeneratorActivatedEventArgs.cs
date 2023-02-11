using System.Linq;
using MapGeneration.Distributors;
using PluginAPI.Core.Zones.Heavy;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Map
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.GeneratorActivated"/>.
	/// </summary>
	public class GeneratorActivatedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="GeneratorActivatedEventArgs"/>.
		/// </summary>
		/// <param name="generator"></param>
		public GeneratorActivatedEventArgs(Scp079Generator generator)
		{
			Generator = Generator.Generators.FirstOrDefault(g => g.Position == generator.transform.position);
		}

		/// <summary>
		/// Gets the generator that was just activated
		/// </summary>
		public Generator Generator { get; }
	}
}