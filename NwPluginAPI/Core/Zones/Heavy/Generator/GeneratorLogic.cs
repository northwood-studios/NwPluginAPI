namespace PluginAPI.Core.Zones.Heavy.Generator
{
	/// <summary>
	/// Handles a generator's logic.
	/// </summary>
	public class GeneratorLogic
	{
		/// <summary>
		/// The generator.
		/// </summary>
		public readonly Generator Generator;

		public virtual bool OnUpdate() => true;

		public virtual bool OnLateUpdate() => true;

		public virtual bool OnPlayerInteraction(Player plr) => true; // GeneratorColliderId colliderId)

		public virtual void OnDestroy() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PluginAPI.Core.Zones.Heavy.GeneratorLogic"/> class.
		/// </summary>
		/// <param name="generator">The generator.</param>
		public GeneratorLogic(Generator generator)
		{
			Generator = generator;
		}
	}
}