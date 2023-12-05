using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerUnmutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUnmuted;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Issuer { get; }
		[EventArgument]
		public bool IsIntercom { get; }

		public PlayerUnmutedEvent(ReferenceHub hub, ReferenceHub issuer, bool isIntercom)
		{
			Player = Player.Get(hub);
			Issuer = issuer == ReferenceHub.HostHub ? Server.Instance : Player.Get(issuer);
			IsIntercom = isIntercom;
		}

		PlayerUnmutedEvent() { }
	}
}
