using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerRemoveHandcuffsEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerRemoveHandcuffs;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }
		[EventArgument]
		public bool CanRemoveHandcuffsAsScp { get; set; } = false;

		public PlayerRemoveHandcuffsEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
		}

		PlayerRemoveHandcuffsEvent() { }
	}
}
