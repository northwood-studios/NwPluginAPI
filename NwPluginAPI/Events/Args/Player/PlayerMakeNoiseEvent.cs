using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerMakeNoiseEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerMakeNoise;
		[EventArgument]
		public Player Player { get; }

		public PlayerMakeNoiseEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		PlayerMakeNoiseEvent() { }
	}
}
