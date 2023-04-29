using MapGeneration.Distributors;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerCloseGeneratorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCloseGenerator;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp079Generator Generator { get; }

		public PlayerCloseGeneratorEvent(ReferenceHub hub, Scp079Generator generator)
		{
			Player = Player.Get(hub);
			Generator = generator;
		}

		PlayerCloseGeneratorEvent() { }
	}
}
