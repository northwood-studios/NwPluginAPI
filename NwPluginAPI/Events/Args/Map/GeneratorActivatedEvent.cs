using MapGeneration.Distributors;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Map
{
	public class GeneratorActivatedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.GeneratorActivated;
		[EventArgument]
		public Scp079Generator Generator { get; }

		public GeneratorActivatedEvent(Scp079Generator generator)
		{
			Generator = generator;
		}

		GeneratorActivatedEvent() { }
	}
}
