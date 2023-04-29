using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp106TeleportPlayerEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp106TeleportPlayer;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }

		public Scp106TeleportPlayerEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
		}

		Scp106TeleportPlayerEvent() { }
	}
}
