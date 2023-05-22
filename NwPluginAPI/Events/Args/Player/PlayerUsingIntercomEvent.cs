using PlayerRoles.Voice;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

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
