using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerLeftEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerLeft;
		[EventArgument]
		public Player Player { get; }

		public PlayerLeftEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		PlayerLeftEvent() { }
	}
}
