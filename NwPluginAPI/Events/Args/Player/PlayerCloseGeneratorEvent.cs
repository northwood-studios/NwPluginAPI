using MapGeneration.Distributors;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerCloseGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCloseGenerator;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp079Generator Generator { get; }

		public PlayerCloseGeneratorEvent(ReferenceHub hub, Scp079Generator generator)
		{
			Player = Core.Player.Get(hub);
			Generator = generator;
		}

		PlayerCloseGeneratorEvent() { }
	}
}
