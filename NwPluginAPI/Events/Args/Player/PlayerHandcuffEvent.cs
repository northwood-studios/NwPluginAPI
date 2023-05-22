using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerHandcuffEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerHandcuff;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }

		public PlayerHandcuffEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
		}

		PlayerHandcuffEvent() { }
	}
}
