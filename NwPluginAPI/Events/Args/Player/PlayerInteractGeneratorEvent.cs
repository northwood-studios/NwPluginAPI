using MapGeneration.Distributors;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using static MapGeneration.Distributors.Scp079Generator;

namespace PluginAPI.Events
{
	public class PlayerInteractGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractGenerator;
		[EventArgument]
		public Player Player { get; }
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
