using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerHandcuffEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerHandcuff;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }

		public PlayerHandcuffEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
		}

		PlayerHandcuffEvent() { }
	}
}
