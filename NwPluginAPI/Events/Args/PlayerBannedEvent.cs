using CommandSystem;

using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

using PluginAPI.Core.Interfaces;
using PluginAPI.Core;

namespace PluginAPI.Events
{
	public class PlayerBannedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerBanned;
		[EventArgument]
		public IPlayer Player { get; }
		[EventArgument]
		public ICommandSender Issuer { get; }
		[EventArgument]
		public string Reason { get; set; }
		[EventArgument]
		public long Duration { get; set; }

		public PlayerBannedEvent(ReferenceHub hub, ICommandSender issuer, string reason, long duration)
		{
			Player = Core.Player.Get(hub);
			Issuer = issuer;
			Reason = reason;
			Duration = duration;
		}

		public PlayerBannedEvent(string userId, string nickName, string ipAddress, ICommandSender issuer, string reason, long duration)
		{
			Player = new OfflinePlayer(userId, nickName, ipAddress);
			Issuer = issuer;
			Reason = reason;
			Duration = duration;
		}

		PlayerBannedEvent() { }
	}
}
