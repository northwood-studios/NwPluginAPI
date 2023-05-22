using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerChangeSpectatorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerChangeSpectator;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player OldTarget { get; }
		[EventArgument]
		public Core.Player NewTarget { get; set; }

		public PlayerChangeSpectatorEvent(ReferenceHub hub, ReferenceHub oldTarget, ReferenceHub newTarget)
		{
			Player = Core.Player.Get(hub);
			OldTarget = Core.Player.Get(oldTarget);
			NewTarget= Core.Player.Get(newTarget);
		}

		PlayerChangeSpectatorEvent() { }
	}
}
