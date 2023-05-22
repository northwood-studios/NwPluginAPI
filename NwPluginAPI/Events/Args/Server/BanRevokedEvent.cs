using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using static BanHandler;

namespace PluginAPI.Events.Args.Server
{
	public class BanRevokedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.BanRevoked;
		[EventArgument]
		public string Id { get; }
		[EventArgument]
		public BanType BanType { get; }

		public BanRevokedEvent(string id, BanType type)
		{
			Id = id;
			BanType = type;
		}

		BanRevokedEvent() { }
	}
}
