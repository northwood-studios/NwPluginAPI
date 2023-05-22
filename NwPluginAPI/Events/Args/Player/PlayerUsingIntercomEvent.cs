using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles.Voice;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUsingIntercomEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUsingIntercom;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public IntercomState IntercomState { get; }

		public PlayerUsingIntercomEvent(ReferenceHub hub, IntercomState state)
		{
			Player = Core.Player.Get(hub);
			IntercomState = state;
		}

		PlayerUsingIntercomEvent() { }
	}
}
