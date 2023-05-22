using MapGeneration.Distributors;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUnlockGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUnlockGenerator;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp079Generator Generator { get; }

		public PlayerUnlockGeneratorEvent(ReferenceHub hub, Scp079Generator generator)
		{
			Player = Player.Get(hub);
			Generator = generator;
		}

		PlayerUnlockGeneratorEvent() { }
	}
}
