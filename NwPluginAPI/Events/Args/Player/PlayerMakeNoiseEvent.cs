using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerMakeNoiseEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerMakeNoise;
		[EventArgument]
		public Core.Player Player { get; }

		public PlayerMakeNoiseEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		PlayerMakeNoiseEvent() { }
	}
}
