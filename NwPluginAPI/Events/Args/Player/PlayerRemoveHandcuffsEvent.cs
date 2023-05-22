using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerRemoveHandcuffsEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerRemoveHandcuffs;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }
		[EventArgument]
		public bool CanRemoveHandcuffsAsScp { get; set; } = false;

		public PlayerRemoveHandcuffsEvent(ReferenceHub hub, ReferenceHub target)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
		}

		PlayerRemoveHandcuffsEvent() { }
	}
}
