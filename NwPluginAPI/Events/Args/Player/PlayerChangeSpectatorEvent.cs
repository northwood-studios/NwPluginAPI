using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerChangeSpectatorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerChangeSpectator;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player OldTarget { get; }
		[EventArgument]
		public Player NewTarget { get; set; }

		public PlayerChangeSpectatorEvent(ReferenceHub hub, ReferenceHub oldTarget, ReferenceHub newTarget)
		{
			Player = Player.Get(hub);
			OldTarget = Player.Get(oldTarget);
			NewTarget= Player.Get(newTarget);
		}

		PlayerChangeSpectatorEvent() { }
	}
}
