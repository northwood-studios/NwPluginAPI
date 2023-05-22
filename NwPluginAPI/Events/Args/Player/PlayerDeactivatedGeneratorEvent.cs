using MapGeneration.Distributors;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDeactivatedGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDeactivatedGenerator;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp079Generator Generator { get; }

		public PlayerDeactivatedGeneratorEvent(ReferenceHub hub, Scp079Generator generator)
		{
			Player = Player.Get(hub);
			Generator = generator;
		}

		PlayerDeactivatedGeneratorEvent() { }
	}
}
