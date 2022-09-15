namespace PluginAPI.Core.Zones.Heavy
{
	public class GeneratorLogic
	{
		public readonly Generator Generator;

		public virtual bool OnUpdate() => true;

		public virtual bool OnLateUpdate() => true;

		public virtual bool OnPlayerInteraction(Player plr) => true;// GeneratorColliderId colliderId)

		public virtual void OnDestroy() { }

		public GeneratorLogic(Generator generator)
		{
			Generator = generator;
		}
	}
}
