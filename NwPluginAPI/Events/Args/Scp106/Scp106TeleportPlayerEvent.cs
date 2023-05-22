using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp106
{
	public class Scp106TeleportPlayerEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp106TeleportPlayer;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }

		public Scp106TeleportPlayerEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
		}

		Scp106TeleportPlayerEvent() { }
	}
}
