using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUseHotkeyEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUseHotkey;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ActionName Action { get; }

		public PlayerUseHotkeyEvent(ReferenceHub hub, ActionName action)
		{
			Player = Core.Player.Get(hub);
			Action = action;
		}

		PlayerUseHotkeyEvent() { }
	}
}
