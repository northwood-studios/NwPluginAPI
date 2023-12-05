using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerMutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerMuted;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Issuer { get; }
		[EventArgument]
		public bool IsIntercom { get; }

		public PlayerMutedEvent(ReferenceHub hub, ReferenceHub issuer, bool isIntercom)
		{
			Player = Player.Get(hub);
			Issuer = issuer == ReferenceHub.HostHub ? Server.Instance : Player.Get(issuer);
			IsIntercom = isIntercom;
		}

		PlayerMutedEvent() { }
	}
}
