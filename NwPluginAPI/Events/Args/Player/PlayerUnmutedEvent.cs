using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUnmutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUnmuted;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Issuer { get; }
		[EventArgument]
		public bool IsIntercom { get; }

		public PlayerUnmutedEvent(ReferenceHub hub, ReferenceHub issuer, bool isIntercom)
		{
			Player = Core.Player.Get(hub);
			Issuer = issuer == ReferenceHub.HostHub ? Core.Server.Instance : Core.Player.Get(issuer);
			IsIntercom = isIntercom;
		}

		PlayerUnmutedEvent() { }
	}
}
