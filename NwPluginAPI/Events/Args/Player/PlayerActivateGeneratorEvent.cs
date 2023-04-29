using MapGeneration.Distributors;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerActivateGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerActivateGenerator;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp079Generator Generator { get; }

		public PlayerActivateGeneratorEvent(ReferenceHub hub, Scp079Generator generator)
		{
			Player = Player.Get(hub);
			Generator = generator;
		}

		PlayerActivateGeneratorEvent() { }
	}
}
