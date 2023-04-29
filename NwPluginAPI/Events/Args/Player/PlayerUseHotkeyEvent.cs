using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerUseHotkeyEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUseHotkey;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ActionName Action { get; }

		public PlayerUseHotkeyEvent(ReferenceHub hub, ActionName action)
		{
			Player = Player.Get(hub);
			Action = action;
		}

		PlayerUseHotkeyEvent() { }
	}
}
