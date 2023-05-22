using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerMutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerMuted;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Issuer { get; }
		[EventArgument]
		public bool IsIntercom { get; }

		public PlayerMutedEvent(ReferenceHub hub, ReferenceHub issuer, bool isIntercom)
		{
			Player = Core.Player.Get(hub);
			Issuer = issuer == ReferenceHub.HostHub ? Core.Server.Instance : Core.Player.Get(issuer);
			IsIntercom = isIntercom;
		}

		PlayerMutedEvent() { }
	}
}
