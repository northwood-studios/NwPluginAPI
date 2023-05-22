using MapGeneration.Distributors;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using static MapGeneration.Distributors.Scp079Generator;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerInteractGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractGenerator;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp079Generator Generator { get; }
		[EventArgument]
		public GeneratorColliderId GeneratorColliderId { get; }

		public PlayerInteractGeneratorEvent(ReferenceHub hub, Scp079Generator generator, GeneratorColliderId generatorColliderId)
		{
			Player = Player.Get(hub);
			Generator = generator;
			GeneratorColliderId = generatorColliderId;
		}

		PlayerInteractGeneratorEvent() { }
	}
}
