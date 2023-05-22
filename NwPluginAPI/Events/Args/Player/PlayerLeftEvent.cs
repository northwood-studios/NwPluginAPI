using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerLeftEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerLeft;
		[EventArgument]
		public Core.Player Player { get; }

		public PlayerLeftEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		PlayerLeftEvent() { }
	}
}
