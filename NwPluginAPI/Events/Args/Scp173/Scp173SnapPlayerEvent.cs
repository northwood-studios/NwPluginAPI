using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp173
{
	public class Scp173SnapPlayerEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173SnapPlayer;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }

		public Scp173SnapPlayerEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
		}

		Scp173SnapPlayerEvent() { }
	}
}
