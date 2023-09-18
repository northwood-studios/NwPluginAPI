using MapGeneration.Distributors;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerActivateGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerActivateGenerator;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp079Generator Generator { get; }

		public PlayerActivateGeneratorEvent(ReferenceHub hub, Scp079Generator generator)
		{
			Player = Core.Player.Get(hub);
			Generator = generator;
		}

		PlayerActivateGeneratorEvent() { }
	}
}
